#!/usr/bin/env python3
"""Hermes skill koleksiyonu doğrulama aracı.

Tüm SKILL.md dosyalarını tarar:
- Frontmatter (name, description) var mı
- Satır ≤500, boyut ≤15KB (skill-evolution constraint)
- `platforms:` satırı YOK (bilinen yara)
- Secret pattern YOK

Çıkış: 0 = temiz, 1 = hata.
"""
import os
import re
import sys

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
SKILLS_DIR = os.path.join(ROOT, "skills")

FRONTMATTER_RE = re.compile(r"^---\s*\n(.*?)\n---\s*\n", re.DOTALL)
NAME_RE = re.compile(r"^name:\s*(.+)$", re.MULTILINE)
DESC_RE = re.compile(r"^description:\s*(.+)$", re.MULTILINE)
PLATFORMS_RE = re.compile(r"^platforms:", re.MULTILINE)
SECRET_RE = re.compile(
    r"gho_[a-zA-Z0-9]{20}|sk-[a-zA-Z0-9]{32}|sk-or-[a-zA-Z0-9]{20}|"
    r"sk-ant-[a-zA-Z0-9]{20}|gsk_[a-zA-Z0-9]{20}|xox[baprs]-[a-zA-Z0-9-]{10}"
)

MAX_LINES = 500
MAX_BYTES = 15 * 1024
# Süper-skill (alt-skill/referans içeren) için esnek limit — tek-dosya kadar serbest
SUPER_MAX_LINES = 1200
SUPER_MAX_BYTES = 70 * 1024
# Doğal büyük tek-dosya skill (claude-code, hermes-agent vb.) hard ceiling
HARD_MAX_LINES = 1200
HARD_MAX_BYTES = 70 * 1024

errors = []
checked = 0


def walk_skills():
    for dirpath, dirnames, filenames in os.walk(SKILLS_DIR):
        # .git gibi internal klasörleri atla
        dirnames[:] = [d for d in dirnames if not d.startswith(".git")]
        for fn in filenames:
            if fn == "SKILL.md":
                yield os.path.join(dirpath, fn)


for path in walk_skills():
    checked += 1
    rel = os.path.relpath(path, ROOT)
    with open(path, encoding="utf-8") as f:
        content = f.read()

    # Frontmatter
    m = FRONTMATTER_RE.match(content)
    if not m:
        errors.append(f"{rel}: frontmatter (---) eksik")
        continue
    fm = m.group(1)
    if not NAME_RE.search(fm):
        errors.append(f"{rel}: 'name:' alanı yok")
    if not DESC_RE.search(fm):
        errors.append(f"{rel}: 'description:' alanı yok")

    # Constraint: satır/boyut (süper-skill için esnek)
    lines = content.count("\n") + 1
    size = len(content.encode("utf-8"))
    parent = os.path.dirname(path)
    is_super = any(
        os.path.isdir(os.path.join(parent, d))
        for d in ("references", "scripts", "templates", "agents", "assets")
    ) or len([d for d in os.listdir(parent) if os.path.isdir(os.path.join(parent, d))]) > 0
    # Tek-dosya skill: HARD_MAX (doğal büyük olabilir)
    # Süper-skill (alt-skill/referans): SUPER_MAX, ama hard ceiling üst sınır
    # Hiçbir skill HARD_MAX'i aşamaz (bölünmesi gerekir)
    if lines > HARD_MAX_LINES:
        errors.append(f"{rel}: {lines} satır (> HARD {HARD_MAX_LINES}, BÖLÜNMELİ)")
    if size > HARD_MAX_BYTES:
        errors.append(f"{rel}: {size} byte (> HARD {HARD_MAX_BYTES}, BÖLÜNMELİ)")
    # Süper-skill için daha sıkı limit (HARD altında)
    if is_super and lines > SUPER_MAX_LINES:
        errors.append(f"{rel}: {lines} satır (> {SUPER_MAX_LINES}, süper-skill)")
    if is_super and size > SUPER_MAX_BYTES:
        errors.append(f"{rel}: {size} byte (> {SUPER_MAX_BYTES}, süper-skill)")

    # Yara: platforms: satırı
    if PLATFORMS_RE.search(content):
        errors.append(f"{rel}: 'platforms:' satırı var (bilinen yara — sil)")

    # Secret
    if SECRET_RE.search(content):
        errors.append(f"{rel}: GERÇEK SECRET pattern'i bulundu")

if errors:
    print(f"[FAIL] {len(errors)} hata ({checked} skill kontrol edildi):")
    for e in errors:
        print(f"  - {e}")
    sys.exit(1)

print(f"[ok] {checked} skill doğrulandı — temiz")
sys.exit(0)

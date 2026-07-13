# Contributing

Bu repo Abdulsamet Derbeder'in kişisel Hermes Agent yapısını içerir.
Katkı için:

## Skill Ekleme / Düzenleme
1. `skills/<isim>/SKILL.md` oluştur/düzenle.
2. Frontmatter zorunlu: `name`, `description` (TRIGGER/DO NOT TRIGGER formatı).
3. Constraint: ≤500 satır, ≤15KB, `platforms:` satırı YOK.
4. `make validate` ile doğrula (local lint).
5. Feature branch aç → PR gönder.

## Doğrulama
```bash
make validate        # tüm skill'leri lint et
make sync            # Hermes'e senkronize et
make changelog       # changelog'a ekle
```

## Güvenlik
- `.env`, `auth.json`, `*.db`, `*.key`, `*.pem` **asla commit ETME**.
- Gerçek API key/token bulursan hemen sil + rotate et.
- `git push --force` main/master YAPMA.

## Commit Mesajı
- Türkçe, fiil odaklı: "feat:", "fix:", "docs:", "refactor:", "security:".
- Kısa ama neyin değiştiği belli olsun.

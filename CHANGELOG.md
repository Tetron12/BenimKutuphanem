# Changelog

Tüm önemli değişiklikler bu dosyada tutulur.
Format: [Keep a Changelog](https://keepachangelog.com/).

## [Unreleased]

## [1.0.0] - 2026-07-13
### Added
- 46 Hermes skill (11 birleşik süper-skill: dev-quality, code-discipline,
  skill-forge, web-research, search-visibility, game-ui-polish, qa-test,
  decision-intel, context-memory, infra-ops, git-workflow)
- `config.yaml`, `cron/`, `profiles/`, `memories/`, `skill-bundles/`, `SOUL.md`
- `.gitignore` ile secret/state dışlama (`.env`, `auth.json`, `*.db`)
- CI: `.github/workflows/validate.yml` (skill lint + secret scan)
- `scripts/validate_skills.py` (local lint aracı)
- `Makefile` (validate, sync, changelog komutları)
- `CONTRIBUTING.md`, `CODE_OF_CONDUCT.md`, `LICENSE`, `README.md`

### Security
- `.env`, `auth.json`, `*.db` repo'dan DışLANDI (secret sızıntısı engellendi)
- Commit öncesi strict secret taraması (git-workflow security-guard kuralı)

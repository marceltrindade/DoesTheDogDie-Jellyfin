# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.2] - 2025-09-04

### Added

- Section in README.md explaining why the plugin was created
- JELLYFIN_SUBMISSION.md with detailed instructions for submitting to official Jellyfin plugin repository
- Plugin icon (poster.png) in PNG format for Jellyfin plugin repository
- Enhanced documentation and contribution guidelines

## [1.0.1] - 2025-09-04

### Fixed

- Plugin not appearing in Jellyfin due to missing meta.json file and incorrect implementation of IHasWebPages interface.
- Configuration page not properly embedded as a resource in the plugin assembly.
- Build script updated to create proper release packages with tar.gz format.

### Added

- meta.json file with plugin metadata for Jellyfin recognition.
- Implementation of IHasWebPages interface for proper configuration page integration.
- Embedded resource configuration for the HTML configuration page.
- Build script to create release packages.
- Contribution guidelines (CONTRIBUTING.md).
- Plugin icon (poster.png) for Jellyfin plugin repository.
- Detailed documentation for publishing releases and submitting to official Jellyfin plugin repository.

## [1.0.0] - 2025-09-03

### Added

- Initial release of the Does The Dog Die? Integration plugin for Jellyfin.
- Feature to scan movie library and query DDD API for triggers.
- Configurable list of triggers to block.
- Application of `DTDD-Bloqueado` tag to matching movies.
- Integration with Jellyfin's Parental Control system via scheduled tasks.
- Basic HTML configuration page for API key and triggers.
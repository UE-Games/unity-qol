# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).


## [1.1.1] - 2022-06-21

### Added

- Singleton.NonPersistentInstance: a new instance that is destroyed during scene changes.

## [1.1.0] - 2022-06-14

### Added

- VLog: New semantically correct API.
- VLog: New colors.

### Deprecated

- VLog: Deprecating color API like VLog.Red() in favor of the new semantically correct APIs.

## [1.0.3] - 2022-05-10

### Changed

- SafeScene.Load(): Adding the load scene mode.

## [1.0.2] - 2022-04-18

### Changed

- Turning on auto-referencing, so that this package can be easily referenced from anywhere.
- VLog: Fixing incorrect class visibility.
- Rider validation settings.
- SafeScene is now public.
- SafeScene: IsSceneLoaded now correctly handles invalid scenes.

## [1.0.1] - 2022-01-04

### Changed

- Now using a different namespace to reflect changes in the parent project structure.

## [1.0.0] - 2022-01-03

### Added

- Initial version.

# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## Unreleased - 2019-01-01
- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/0.0.0...0.0.0)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/0?closed=1)

### Added
- Nothing.

### Changed
- Nothing.

### Deprecated
- Nothing.

### Removed
- Nothing.

### Fixed
- Nothing.

### Security
- Nothing.

## 1.2.0 - 2019-09-08
- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/1.1.0...1.2.0)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/4?closed=1)

### Added
- `IInitializeAsync`: `IsAsyncInitialized` and `IsAsyncInProgress` to determine a state of the async initialization.

## 1.1.0 - 2019-09-03
- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/1.0.0...1.1.0)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/3?closed=1)

### Added
- `InitializeState`: name for debugging name of the state when `InitializeStateException` thrown.
- `InitializeState.ValidateState` to validate expected state.
- `InitializeUtility.ValidateState` overloads to check `InitializeState` or `IInitialize` state.
- `InitializeExtensions.ValidateState` for `IInitialize` interface as replacement of deprecated method.

### Deprecated
- `InitializeUtility.ValidateState`: use another overload or extension method.

## 1.0.0 - 2019-08-28
- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/1.0.0-preview...1.0.0)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/2?closed=1)

### Added
- Package short description.
- `IInitializeAsync` and `InitializeBaseAsync` for implementing async initialization.

### Changed
- Update to Unity 2019.2.

## 1.0.0-preview - 2019-06-29
- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/28d71db...1.0.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/1?closed=1)

### Added
- This is a initial release.

---
> Unity Game Framework | Copyright 2019

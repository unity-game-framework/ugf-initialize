# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.8.0](https://github.com/unity-game-framework/ugf-initialize/releases/tag/2.8.0) - 2022-01-14  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/13?closed=1)  
    

### Changed

- Change Initializable to make children always ready for init and unini methods ([#36](https://github.com/unity-game-framework/ugf-initialize/issues/36))  
    - Change `Initializable` class to use `OnPreInitialize` and `OnPostUninitialize` methods to initialize children.

## [2.7.0](https://github.com/unity-game-framework/ugf-initialize/releases/tag/2.7.0) - 2021-11-23  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/12?closed=1)  
    

### Added

- Add InitializeCollectionExtensions ([#35](https://github.com/unity-game-framework/ugf-initialize/pull/35))  
    - Update package publish registry.
    - Update package _Unity_ version to `2020.3`.
    - Add `IInitializeCollection.Create<T>()` method as shortcut for creation into collection.
    - Add `IInitializeCollection.TryGet<TArguments, T>()` method to get item from collection using specified predicate.

## [2.6.0](https://github.com/unity-game-framework/ugf-initialize/releases/tag/2.6.0) - 2020-11-30  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/11?closed=1)  
    

### Changed

- Add initializable with children ([#32](https://github.com/unity-game-framework/ugf-initialize/pull/32))  
    - Add `Initializable.Children` as `IInitializeCollection` collection.
    - Change `InitializeCollection.ReverseUninitializationOrder` to set from constructor only.

## [2.5.0](https://github.com/unity-game-framework/ugf-initialize/releases/tag/2.5.0) - 2020-11-10  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/10?closed=1)  
    

### Changed

- Update to Unity 2020.2 ([#29](https://github.com/unity-game-framework/ugf-initialize/pull/29))

## [2.4.0](https://github.com/unity-game-framework/ugf-initialize/releases/tag/2.4.0) - 2020-09-02  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/9?closed=1)  
    

### Added

- Add Initializable as default implementation of InitializeBase ([#23](https://github.com/unity-game-framework/ugf-initialize/pull/23))  

### Changed

- Add check for initialize state InitializeScope dispose ([#22](https://github.com/unity-game-framework/ugf-initialize/pull/22))

## [2.3.0-preview](https://github.com/unity-game-framework/ugf-initialize/releases/tag/2.3.0-preview) - 2020-02-19  

- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/2.2.0-preview...2.3.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/8?closed=1)

### Changed
- Rework `InitializeCollection` collection.

## [2.2.0-preview](https://github.com/unity-game-framework/ugf-initialize/releases/tag/2.2.0-preview) - 2020-02-15  

- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/2.1.0-preview...2.2.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/7?closed=1)

### Changed
- Change `InitializeCollection` to generic.

## [2.1.0-preview](https://github.com/unity-game-framework/ugf-initialize/releases/tag/2.1.0-preview) - 2020-02-15  

- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/2.0.0-preview...2.1.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/6?closed=1)

### Added
- Add `InitializeScope` to automatically uninitialize target after scope.
- Add `InitializeStateException` default constructor.
- Add `OnPostInitialize` and `OnPreUninitialize` overridable methods.
- Add `InitializeCollection` to initialize or uninitialize collection of targets.

### Removed
- Removed deprecated code.

## [2.0.0-preview](https://github.com/unity-game-framework/ugf-initialize/releases/tag/2.0.0-preview) - 2019-11-18  

- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/1.2.0...2.0.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/5?closed=1)

### Added
- `IInitialize.Initialized` and `IInitialize.Uninitialized` events.

### Changed
- Update to Unity 2019.3.
- Rework `InitializeState` to immutable unit.

### Deprecated
- `IInitializeAsync` has been deprecated and will be removed at next releases.

## [1.2.0](https://github.com/unity-game-framework/ugf-initialize/releases/tag/1.2.0) - 2019-09-08  

- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/1.1.0...1.2.0)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/4?closed=1)

### Added
- `IInitializeAsync`: `IsAsyncInitialized` and `IsAsyncInProgress` to determine a state of the async initialization.

## [1.1.0](https://github.com/unity-game-framework/ugf-initialize/releases/tag/1.1.0) - 2019-09-03  

- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/1.0.0...1.1.0)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/3?closed=1)

### Added
- `InitializeState`: name for debugging name of the state when `InitializeStateException` thrown.
- `InitializeState.ValidateState` to validate expected state.
- `InitializeUtility.ValidateState` overloads to check `InitializeState` or `IInitialize` state.
- `InitializeExtensions.ValidateState` for `IInitialize` interface as replacement of deprecated method.

### Deprecated
- `InitializeUtility.ValidateState`: use another overload or extension method.

## [1.0.0](https://github.com/unity-game-framework/ugf-initialize/releases/tag/1.0.0) - 2019-08-28  

- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/1.0.0-preview...1.0.0)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/2?closed=1)

### Added
- Package short description.
- `IInitializeAsync` and `InitializeBaseAsync` for implementing async initialization.

### Changed
- Update to Unity 2019.2.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-initialize/releases/tag/1.0.0-preview) - 2019-06-29  

- [Commits](https://github.com/unity-game-framework/ugf-initialize/compare/28d71db...1.0.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-initialize/milestone/1?closed=1)

### Added
- This is a initial release.



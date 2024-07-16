# Interpolation Package

This package offers a collection of interpolation utilities for Unity projects.

## Features
- Frame-independent decay for smooth transitions between values.

## Requirements
- Unity 2021.3 or later

## Installation
To use the Interpolation package in your project, import the `com.lvl3mage.interpolation` package.

## Usage
The `Decay` class provides static methods to smoothly interpolate between two values, angles, or vectors over time, independent of the frame rate. This is particularly useful for animations and movement smoothing.

Example usage:
```csharp
float newValue = Decay.To(currentValue, targetValue, speed, Time.deltaTime);

using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libAspects.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true)]

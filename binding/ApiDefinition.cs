using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Aspects
{
	interface IAspect { }

	[BaseType (typeof (NSObject))]
	[Protocol]
	interface Aspect
	{
		[Abstract]
		[Export ("remove")]
		bool Remove ();
	}

	delegate void AspectHandler (NSObject instance, NSObject[] args);

	[BaseType (typeof (NSObject))]
	[Category]
	interface AspectsExtensions
	{
		[Static]
		[Export ("aspect_hookSelector:withOptions:usingBlock:error:")]
		IAspect HookSelectorToClass (Selector selector, AspectOptions options, AspectHandler handler, out NSError error);

		[Export ("aspect_hookSelector:withOptions:usingBlock:error:")]
		IAspect HookSelectorToInstance (Selector selector, AspectOptions options, AspectHandler handler, out NSError error);
	}
}
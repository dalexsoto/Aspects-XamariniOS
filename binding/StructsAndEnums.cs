using System;

namespace Aspects
{
	public enum AspectOptions : uint
	{
		PositionAfter   = 0,            /// Called after the original implementation (default)
		PositionInstead = 1,            /// Will replace the original implementation.
		PositionBefore  = 2,            /// Called before the original implementation.

		AutomaticRemoval = 1 << 3 /// Will remove the hook after the first execution.
	}

	public enum AspectsErrorCode
	{
		SelectorBlacklisted,                   /// Selectors like release, retain, autorelease are blacklisted.
		DoesNotRespondToSelector,              /// Selector could not be found.
		SelectorDeallocPosition,               /// When hooking dealloc, only AspectPositionBefore is allowed.
		SelectorAlreadyHookedInClassHierarchy, /// Statically hooking the same method in subclasses is not allowed.
		FailedToAllocateClassPair,             /// The runtime failed creating a class pair.
		RemoveObjectAlreadyDeallocated = 100   /// (for removing) The object hooked is already deallocated.
	}
}


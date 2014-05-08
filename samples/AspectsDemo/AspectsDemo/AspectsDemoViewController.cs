using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Aspects;
using MonoTouch.ObjCRuntime;

namespace AspectsDemo
{
	public partial class AspectsDemoViewController : UIViewController
	{
		public AspectsDemoViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		partial void ButtonPressed (UIButton sender)
		{
			var testController = new UIImagePickerController {
				ModalPresentationStyle = UIModalPresentationStyle.FormSheet
			};
			PresentViewController (testController, true, null);
			NSError error;

			// We are interested in being notified when the controller is being dismissed.
			testController.HookSelectorToInstance (new Selector ("viewWillDisappear:"), AspectOptions.PositionAfter, (instance, args) => {
				var controller = instance as UIViewController;
				if (controller.IsBeingDismissed || controller.IsMovingFromParentViewController) {
					new UIAlertView ("Popped", "Hello from Aspects", null, "Ok", null).Show ();
				}
			}, out error);

			// We are interested in being notified when the controller did dissapear.
			testController.HookSelectorToInstance (new Selector ("viewDidDisappear:"), AspectOptions.PositionAfter, (instance, args) => {
				Console.WriteLine ("Controller did disappear: {0}", instance);
				View.BackgroundColor = UIColor.Green;
			}, out error);
		}

		#endregion
	}
}


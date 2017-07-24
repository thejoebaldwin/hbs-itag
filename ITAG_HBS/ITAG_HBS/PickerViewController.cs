﻿﻿﻿﻿﻿﻿using System;
using Foundation;
using UIKit;
using CoreGraphics;
using HBS.ITAG.Model;
using System.Drawing;
using CoreAnimation;
using System.Collections.Generic;

namespace HBS.ITAG
{
    public partial class PickerViewController : UIViewController
    {
        User tempUser;
		public List<string> ages = new List<string>
		{
			"16 and Under",
			"17 to 20",
			"21 to 25",
			"26 to 30",
			"31 to 35",
			"36 to 40",
			"41 to 45",
			"46 to 50",
			"51 to 55",
			"56 to 60",
			"61 to 65",
			"66 to 70",
			"70 and Above"
		};

        public List<string> genders = new List<string>
        {
			"Male",
			"Female",
			"Other",
			"Prefer Not to Respond"
        };

        public List<string> techFoci = new List<string>
        {
			"IT",
			"GIS",
			"Both",
			"None"
        };

        public List<string> organizations = new List<string>
        {
			"IGIC",
			"ICIT",
			"Both",
			"None"
        };

        public List<string> states = new List<string>
        {
            "AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS", "MT", "NC", "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", "WI", "WV", "WY"
        };

		public PickerViewController(IntPtr handle) : base(handle)
        {
            
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

			PositionTitle.Started += (sender, e) =>
			{
				View.Frame = new CoreGraphics.CGRect(View.Frame.X, View.Frame.Y - 75, View.Frame.Size.Width, View.Frame.Size.Height);
                AgeTextView.Editable = false;
                GenderTextView.Editable = false;
                TechFocusTextView.Editable = false;
                OrganizationTextView.Editable = false;
				AgeTextView.Selectable = false;
				GenderTextView.Selectable = false;
				TechFocusTextView.Selectable = false;
				OrganizationTextView.Selectable = false;
			};

            PositionTitle.Ended += (sender, e) =>
            {
                View.Frame = new CoreGraphics.CGRect(View.Frame.X, View.Frame.Y + 75, View.Frame.Size.Width, View.Frame.Size.Height);
                AgeTextView.Editable = true;
                GenderTextView.Editable = true;
                TechFocusTextView.Editable = true;
                OrganizationTextView.Editable = true;
                AgeTextView.Selectable = true;
                GenderTextView.Selectable = true;
                TechFocusTextView.Selectable = true;
                OrganizationTextView.Selectable = true;
            };

            UIToolbar toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, (float)this.View.Frame.Size.Width, 44.0f));
            toolbar.TintColor = UIColor.White;
            toolbar.BarStyle = UIBarStyle.Black;
            toolbar.Translucent = true;
            toolbar.Items = new UIBarButtonItem[]{
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate
                {
					if(this.AgeTextView.ResignFirstResponder())
					{
						this.AgeTextView.Text = ages[(int)this.AgePickerView.SelectedRowInComponent(0)];
					}
					else if(this.GenderTextView.ResignFirstResponder())
					{
						this.GenderTextView.Text = genders[(int)this.GenderPickerView.SelectedRowInComponent(0)];
					}
					else if(this.TechFocusTextView.ResignFirstResponder())
					{
						this.TechFocusTextView.Text = techFoci[(int)this.TechFocusPickerView.SelectedRowInComponent(0)];
					}
					else if(this.OrganizationTextView.ResignFirstResponder())
					{
						this.OrganizationTextView.Text = organizations[(int)this.OrganizationPickerView.SelectedRowInComponent(0)];
					}

                    this.PositionTitle.ResignFirstResponder();
                    this.AgeTextView.ResignFirstResponder();
					this.GenderTextView.ResignFirstResponder();
					this.TechFocusTextView.ResignFirstResponder();
					this.OrganizationTextView.ResignFirstResponder();
                })
             };

            //tint color is for the cursor of the textviews
            this.AgeTextView.TintColor = UIColor.Clear;
            this.GenderTextView.TintColor = UIColor.Clear;
            this.TechFocusTextView.TintColor = UIColor.Clear;
            this.OrganizationTextView.TintColor = UIColor.Clear;
            this.PositionTitle.KeyboardAppearance = UIKeyboardAppearance.Dark;
            this.PositionTitle.KeyboardType = UIKeyboardType.ASCIICapable;
            this.PositionTitle.InputAccessoryView = toolbar;
            this.AgePickerView.RemoveFromSuperview();
            this.AgeTextView.InputView = AgePickerView;
            this.AgeTextView.InputAccessoryView = toolbar;
            var agePickerViewModel = new AgeModel(ages);

            agePickerViewModel.ageChanged += (sender, e) =>
            {
                AgeTextView.Text = agePickerViewModel.selectedAge;
            };
            AgePickerView.Model = agePickerViewModel;

            this.GenderPickerView.RemoveFromSuperview();
            this.GenderTextView.InputView = GenderPickerView;
            this.GenderTextView.InputAccessoryView = toolbar;
            var genderPickerViewModel = new GenderModel(genders);

            genderPickerViewModel.genderChanged += (sender, e) =>
            {
                GenderTextView.Text = genderPickerViewModel.selectedGender;
            };
            GenderPickerView.Model = genderPickerViewModel;
            //Uncomment below code and create TextView and Picker view to include State on Survey Page

            //this.StatePickerView.RemoveFromSuperview();
            //this.StateTextView.InputView = StatePickerView;
            //this.StateTextView.InputAccessoryView = toolbar;
            //var statePickerViewModel = new StateModel(states);
            //statePickerViewModel.stateChanged += (sender, e) =>
            //{
            //	StateTextView.Text = statePickerViewModel.selectedState;
            //};
            //StatePickerView.Model = statePickerViewModel;

            this.TechFocusPickerView.RemoveFromSuperview();
            this.TechFocusTextView.InputView = TechFocusPickerView;
            this.TechFocusTextView.InputAccessoryView = toolbar;
            var techFocusPickerViewModel = new TechFocusModel(techFoci);
            techFocusPickerViewModel.techFocusChanged += (sender, e) =>
            {
                TechFocusTextView.Text = techFocusPickerViewModel.selectedTechFocus;
            };
            TechFocusPickerView.Model = techFocusPickerViewModel;

            this.OrganizationPickerView.RemoveFromSuperview();
            this.OrganizationTextView.InputView = OrganizationPickerView;
            this.OrganizationTextView.InputAccessoryView = toolbar;
            var organizationPickerViewModel = new OrganizationModel(organizations);

            organizationPickerViewModel.organizationChanged += (sender, e) =>
            {
                OrganizationTextView.Text = organizationPickerViewModel.selectedOrganization;
            };
            OrganizationPickerView.Model = organizationPickerViewModel;

            SubmitForm.UserInteractionEnabled = true;
            UITapGestureRecognizer SubmitFormGesture = new UITapGestureRecognizer(SubmitFormClick);
            SubmitFormGesture.NumberOfTapsRequired = 1;
            SubmitForm.AddGestureRecognizer(SubmitFormGesture);
        }

		public void AddBarButtonText(object sender, EventArgs e)
		{
			var barButtonItem = sender as UIBarButtonItem;
			if (barButtonItem != null)
				this.PositionTitle.Text += barButtonItem.Title;
            var agetextitem = sender as UIBarButtonItem;
           if (agetextitem != null)
              this.AgeTextView.Text += agetextitem.Title;
		}

        private void SubmitFormClick()
        {
            if(this.AgeTextView.Text == "Choose One" || this.GenderTextView.Text == "Choose One" || this.TechFocusTextView.Text == "Choose One" || this.OrganizationTextView.Text == "Choose One")
            {
	            if (this.AgeTextView.Text == "Choose One")
	            {
	                InvokeOnMainThread(() =>
	                {
	                    this.AgeTextView.Layer.BorderColor = UIColor.Red.CGColor;
	                    this.AgeTextView.Layer.BorderWidth = 2;
	                    this.AgeTextView.Layer.CornerRadius = 5;
	                });
	            }
                else
                {
					this.AgeTextView.Layer.BorderWidth = 0;
                }
	            if (this.GenderTextView.Text == "Choose One")
	            {
	                InvokeOnMainThread(() =>
	                {
	                    this.GenderTextView.Layer.BorderColor = UIColor.Red.CGColor;
	                    this.GenderTextView.Layer.BorderWidth = 2;
	                    this.GenderTextView.Layer.CornerRadius = 5;
	                });
	            }
                else
                {
                    this.GenderTextView.Layer.BorderWidth = 0;
                }
	            if (this.TechFocusTextView.Text == "Choose One")
	            {
	                InvokeOnMainThread(() =>
	                {
	                    this.TechFocusTextView.Layer.BorderColor = UIColor.Red.CGColor;
	                    this.TechFocusTextView.Layer.BorderWidth = 2;
	                    this.TechFocusTextView.Layer.CornerRadius = 5;
	                });
	            }
                else
                {
                    this.TechFocusTextView.Layer.BorderWidth = 0;
                }
                if(this.OrganizationTextView.Text == "Choose One")
	            {
	                InvokeOnMainThread(() =>
	                {
	                    this.OrganizationTextView.Layer.BorderColor = UIColor.Red.CGColor;
	                    this.OrganizationTextView.Layer.BorderWidth = 2;
	                    this.OrganizationTextView.Layer.CornerRadius = 5;
	                });
	            }
                else
                {
                    this.OrganizationTextView.Layer.BorderWidth = 0;
                }
            }
            else
            {
				tempUser = new User("-1",
							ages[(int)AgePickerView.SelectedRowInComponent(0)],
							genders[(int)GenderPickerView.SelectedRowInComponent(0)],
							techFoci[(int)TechFocusPickerView.SelectedRowInComponent(0)],
							organizations[(int)OrganizationPickerView.SelectedRowInComponent(0)],
							PositionTitle.Text,
							//StateModel.States[StatePickerView.SelectedRowInComponent(0)],
							"iOS",
							UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString());
				Store.Instance.AddUser(tempUser, AddUserComplete);
            }
		}
	
        private void AddUserComplete(string message)
        {
            this.DismissViewController(true, null);
        }

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
		}
	}
}


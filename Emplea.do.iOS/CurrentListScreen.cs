using System;
using System.Collections.Generic;
using System.Linq;
using Empleado;
using MBProgressHUD;
using MonoTouch.Dialog;
using MonoTouch.UIKit;
using iOS.Model;
using iOS.View.JobPosting;

namespace iOS
{
    public class CurrentListScreen : DialogViewController
    {
        private readonly WebDataHelper _helper;
       // private UIButton button;
       // private float buttonHeight = 50;
       // private float buttonWidth = 200;
      //  private MTMBProgressHUD hud;
      //  private int numClicks = 0;
        public CurrentListScreen() : this(new WebDataHelper())
        {
        }

        private CurrentListScreen(WebDataHelper helper) : base(new RootElement("Vigentes"), true)
        {
            _helper = helper;
            Style = UITableViewStyle.Grouped;
            EnableSearch = true;
            SetupRefreshControl();
        }

        private void SetupRefreshControl()
        {
            RefreshControl = new UIRefreshControl();
            RefreshControl.ValueChanged += RefreshControl_ValueChanged;
        }

        private void RefreshControl_ValueChanged(object sender, EventArgs e)
        {
            CreateScreen();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			var e = new StyledMultilineElement("Ahorra data", "Ala hacia bajo cuando quieras refrescar"){Lines=3};
            Root.Add(new Section {e});
            ReloadData();
			CreateScreen();
        }

        public override void ViewDidAppear(bool animated)
        {
			CreateScreen ();
		}
        //    base.ViewDidAppear(animated);
        //    hud = new MTMBProgressHUD(View)
        //    {
        //        LabelText = @"Cargando Blocks...",
        //        RemoveFromSuperViewOnHide = true
        //    };

        //    View.AddSubview(hud);
        //    View.BringSubviewToFront(hud);

        //    hud.Show(animated: true);

        //    CreateScreen();
        //    hud.Hide(animated: true, delay: .5);
        //}

        private void CreateScreen()
        {
           // EdgesForExtendedLayout = UIRectEdge.None;


            new Proxy().GetActive(BindData, Error);
        }

        private void Error(string s)
        {
			Root.Clear ();
			var ex = new StyledMultilineElement("Exception",s, UITableViewCellStyle.Value2){Lines=0};

			Root.Add(new Section { ex});
			ReloadData();
			if (RefreshControl != null) RefreshControl.EndRefreshing();
        }

        private void BindData(IList<JobPosting> postings)
        {
            if (postings.Any())
            {
                IEnumerable<JobPostingRootElement> postingElements =
                    from p in postings
                    select
                        new JobPostingRootElement(p, true,
                                                  rootElement =>
                                                  new DialogViewController(UITableViewStyle.Plain, rootElement, true));


                var section = new Section(string.Format("Vigentes {0}", postings.Count));

                section.AddAll(postingElements);

                Root.Clear();
                Root.Add(section);
                ReloadData();
            }
            else
            {
                Root.Clear();
				var e = new StyledMultilineElement("Error",@"El servidor no me di"){LineBreakMode =  UILineBreakMode.WordWrap, Lines=2};
                Root.Add(new Section {e});
                ReloadData();
            }

            if (RefreshControl != null) RefreshControl.EndRefreshing();
        }
    }
}
using System;
using System.Drawing;
using System.Globalization;
using Framework.iOS.MTD;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using RestSharp.Contrib;

namespace iOS.View.JobPosting
{
    public class JobPostingCell : ModelBasedCell<Model.JobPosting>
    {
        private readonly bool _showIndicator;
        private UILabel _company;
        private UITextView _description;
        private UILabel _title;
        private UILabel _location;
        private UILabel _updated;
        private UILabel _url;

        public JobPostingCell(NSString key, bool showIndicator) : base(key)
        {
            _showIndicator = showIndicator;
            ApplyStyle();
        }

        public override void Update(Model.JobPosting source)
        {
            _title.Text = source.title;
            _company.Text = source.company_name;
            _description.Text = HttpUtility.HtmlDecode(source.description_clean);
            _location.Text = source.location;
            _url.Text = source.company_url;

            var updated = DateTime.Parse(source.created_at);
            _updated.Text = updated.ToString("dd MMM,yyyy", new CultureInfo("es-ES"));

        }

        protected override sealed void ApplyStyle()
        {
            if (!_showIndicator) return;
            Accessory = UITableViewCellAccessory.DisclosureIndicator;
            SelectionStyle = UITableViewCellSelectionStyle.None;
        }

        protected override void CreateContent()
        {
            float topMargin = 5f;
            float leftMargin = 10f;
            float rightMargin = 30f;
          //  int lineSeparator = 5;
            float yGuide = topMargin;

            _title = new UILabel
                {
                    Lines = 1,
                    Font = Fonts.BoldPrimaryFont(14f),
                    Frame = new RectangleF(leftMargin, yGuide, ContentView.Frame.Width - (rightMargin+100), 16),
                   // BackgroundColor = UIColor.Green
                };

            _updated = new UILabel
            {
                Lines = 1,
                Font = Fonts.BoldPrimaryFont(12f),
                Frame = new RectangleF( leftMargin + _title.Frame.Width + 5, yGuide, ContentView.Frame.Width - (rightMargin + _title.Frame.Width + 5), 14),
               // BackgroundColor = UIColor.Purple
            };

            yGuide += 16;

            _company = new UILabel
                {
                    Lines = 1,
                    Font = Fonts.PrimaryFont(12f),
                    TextColor = UIColor.Gray,
                    Frame = new RectangleF(leftMargin, yGuide, ContentView.Frame.Width -(rightMargin + 100), 14),
                  //  BackgroundColor = UIColor.Red
                };

            _location = new UILabel
            {
                Lines = 1,
                Font = Fonts.PrimaryFont(12f),
                TextColor = UIColor.Gray,
                Frame = new RectangleF(_company.Frame.Width + 5, yGuide, ContentView.Frame.Width - (_company.Frame.Width + rightMargin +5), 14),
               // BackgroundColor = UIColor.Yellow
            };

            yGuide +=14;
         
            _url = new UILabel()
            {
                //ScrollEnabled = false, 
               // DataDetectorTypes = UIDataDetectorType.Link,
                Font = Fonts.PrimaryFont(12f),
             //   BackgroundColor = UIColor.Magenta,
                TextColor = UIColor.Blue,
                Frame = new RectangleF(leftMargin, yGuide, ContentView.Frame.Width - (rightMargin + 100), 14)
              };
            
            
            yGuide += 14;

            _description = new UITextView
                {
               		 Editable= false,   	
					ScrollEnabled = false,
                    Font = Fonts.PrimaryFont(12f), 
                    TextAlignment = UITextAlignment.Natural,
                   Frame = new RectangleF(leftMargin, yGuide, ContentView.Frame.Width - rightMargin, 70)
                   
                };


            ContentView.AddSubviews(_title, _company, _description, _location, _updated, _url);
        }
    }
}
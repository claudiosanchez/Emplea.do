using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iOS.Model
{
    /// <summary>
    /// 
    /// http://www.emplea.do/1.0/jobs_vigentes.json
    /// </summary>
    
    public class JobPosting
    {
        public string apply { get; set; }
        public int category_id { get; set; }
        public string company_email { get; set; }
        public object company_logo_content_type { get; set; }
        public object company_logo_file_name { get; set; }
        public object company_logo_file_size { get; set; }
        public object company_logo_updated_at { get; set; }
        public string company_name { get; set; }
        public string company_url { get; set; }
        public string created_at { get; set; }
        public int days { get; set; }
        public int id { get; set; }
        public string location { get; set; }
        public int nivel { get; set; }
        public bool published { get; set; }
        public string title { get; set; }
        public string updated_at { get; set; }
        public string description_clean { get; set; }
    }
}

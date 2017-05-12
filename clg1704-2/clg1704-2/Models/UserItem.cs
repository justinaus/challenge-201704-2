using System;
using clg17042.Helpers;
using Newtonsoft.Json;

namespace clg17042.Models
{
    public class UserItem : ObservableObject
    {

		string gender = string.Empty;
		public string Gender
		{
			get { return gender; }
			set { SetProperty(ref gender, value); }
		}

		string cellPhoneNumber = string.Empty;
        [JsonProperty("cell")]
		public string CellPhoneNumber
		{
			get { return cellPhoneNumber; }
			set { SetProperty(ref cellPhoneNumber, value); }
		}

		Name name = null;
        public Name Name
		{
			get { return name; }
			set { SetProperty(ref name, value); }
		}

        Picture picture = null;
		public Picture Picture
		{
			get { return picture; }
			set { SetProperty(ref picture, value); }
		}

		//string id = string.Empty;

		//[JsonIgnore]
		//public string Id
		//{
		//	get { return id; }
		//	set { SetProperty(ref id, value); }
		//}

    }


	public class Name : ObservableObject
	{
		/// <summary>
		/// 호칭 
		/// Mr Mrs Ms Miss or etc
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// First Name
		/// </summary>
		public string First { get; set; }
		/// <summary>
		/// Last Name
		/// </summary>
		public string Last { get; set; }
	}

    public class Picture : ObservableObject 
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Thumbnail { get; set; }
    }
}

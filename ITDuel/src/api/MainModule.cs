using System;
using System.Text;
using System.Net;
using System.Xml.Serialization;
using System.Collections.Generic;
using Nancy.Extensions;
using Newtonsoft.Json;

namespace Nancy.FourColors
{
	public class MainModule : NancyModule
	{
		public MainModule()
		{
			Post ["/games"] = args => {
				Console.WriteLine ("[POST] /games");

                var json1 = this.Request.Body.AsString();

                Console.WriteLine ("JSON: " + json1);

                var array = Helper.GetArrayFromJson(json1);
                var regions = FieldParser.Parse(array);
				var json = "{\"status\": \"ok\"}";

				var json_response = (Response)json;
				json_response.ContentType = "application/json";

				return json_response;
			};

			Get ["/games/{id}"] = args => {
				Console.WriteLine ("[GET] /games/{id}");
				Console.WriteLine ("ID = " + args.id);

				foreach (KeyValuePair<string, dynamic> arg in this.Request.Query.ToDictionary())
				{
					Console.WriteLine("arg = {0}, value = {1}", arg.Key, arg.Value);
				};

                var rnd = new Random();
				var json = "{\"status\": \"ok\",\"figure\": " + rnd.Next(0, Helper.MaxId) + "}";
                Console.WriteLine(json);

				var json_response = (Response)json;
				json_response.ContentType = "application/json";

				return json_response;
			};

			Put ["/games/{id}"] = args => {
				Console.WriteLine ("[PUT] /games/{id}");
				Console.WriteLine ("ID = " + args.id);

				Console.WriteLine ("JSON: " + this.Request.Body.AsString());

				var json = "{\"status\": \"ok\"}";

				var json_response = (Response)json;
				json_response.ContentType = "application/json";

				return json_response;
			};

			Delete ["/games/{id}"] = args => {
				Console.WriteLine ("[DELETE] /games/{id}");
				Console.WriteLine ("ID = " + args.id);

                Helper.MaxId = 0;

				var json = "{\"status\": \"ok\"}";

				var json_response = (Response)json;
				json_response.ContentType = "application/json";

				return json_response;
			};

			Get ["/"] = args => {
				Console.WriteLine ("[GET] /");

				return "ROOT";
			};
		}
	}
}

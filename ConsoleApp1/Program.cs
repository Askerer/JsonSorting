using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;


namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			using (StreamReader sr = new StreamReader(Application.StartupPath + "\\json1.json"))
			{
				//1.讀取檔案的文字
				string jsonstr = sr.ReadToEnd();

				//2.Json字串轉成物件
				JObject obj = JObject.Parse(jsonstr);

				//3.想對物件中的Array進行排序
				JArray ary = (JArray) obj["Contact"];

				//4.JArray轉成 List<dynamic> 
				List<dynamic> LstWindow = ary.ToList<dynamic>();

				//5.透過Lambda Orderby做排序
				var a = LstWindow.OrderBy(o => o.window.priority);

				//6.回到JArray
				JArray orderAry = JArray.FromObject(a);

				//7. 將原本物件的Array替換~
				obj["Contact"] = orderAry;

				

			}


			

		}
	}
}

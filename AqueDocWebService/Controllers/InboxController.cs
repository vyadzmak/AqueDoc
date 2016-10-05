using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AqueDocWebService.Models;

namespace AqueDocWebService.Controllers
{
    public class InboxController : ApiController
    {
        // GET api/inbox
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/inbox/5
        public List<InboxMailModel> Get(int id)
        {
            //
            int counter = 10;
            List<InboxMailModel> result = new List<InboxMailModel>();

            List<string> captions = new List<string>()
            {
                "По поводу тестирования",
                "Отчет за период",
                "Рассылка сотрудникам",
                "Приказ на оформление"
            };

            List<string> descriptions = new List<string>()
            {
                "Проверить состояние отчета",
                "Сверстать макет под необходимый проект",
                "ПОдобрать оригинальный дизайн",
                "Подписать прикрепленные документы"
            };

            List<string> names = new List<string>()
            {
                "Иванов Иван Иванович",
                "Петров Петр Петрович",
                "Сидоров Сидор Сидорович",
                "Андреев Андрей Андреевич"
            };
            Random r = new Random();
            
            for (int i = 0; i < counter; i++)
            {
               // Task.WaitAll(Task.Delay(10));
                int n = r.Next(0, 4);
                string caption = captions[n];
                
                n = r.Next(0, 4);
                string description = descriptions[n];

                n = r.Next(0, 4);
                string name = names[n];

                string text =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod ... Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ... Ut ullamcorper, ligula eu tempor congue, eros est euismod turpis, id tincidunt ... elit ut dictum aliquet, felis nisl adipiscing sapien, sed malesuada diam lacus eget erat.";

                result.Add(new InboxMailModel {Id=i.ToString(), Caption = caption, DateTime = DateTime.Now.ToString(), Description = description, SubjectName =name, Text = text});
           

            }

//             result.Add(new InboxMailModel { Caption = "Письмо №2", DateTime = DateTime.Now.ToString(), Description = "Привет как дела?", SubjectName = "" });
//            result.Add(new InboxMailModel { Caption = "Письмо №3", DateTime = DateTime.Now.ToString(), Description = "Привет как дела?", SubjectName = "" });
//            result.Add(new InboxMailModel { Caption = "Письмо №4", DateTime = DateTime.Now.ToString(), Description = "Привет как дела?", SubjectName = "" });
//            
            return result;
        }

        // POST api/inbox
        public void Post([FromBody]string value)
        {
        }

        // PUT api/inbox/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/inbox/5
        public void Delete(int id)
        {
        }
    }
}

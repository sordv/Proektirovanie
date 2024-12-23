using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class Roadmap
    {
        public string Country { get; set; }
        public bool IsHighlyQualified { get; set; }
        public bool IsRelocationParticipant { get; set; }
        public bool NeedsPatent { get; private set; }
        public bool CanGetPatent { get; private set; }
        public List<string> Steps { get; private set; }

        public Roadmap()
        {
            Steps = new List<string>();
        }

        public void DeterminePatentRequirement()
        {
            var exemptCountries = new List<string>
            {
                "Азербайджан",
                "Кыргызстан",
                "Молдова",
                "Таджикистан",
                "Украина",
                "Другая страна"
            };

            // Проверяем возможность получения патента
            if (exemptCountries.Contains(Country) && Country == "Другая страна")
            {
                CanGetPatent = false;
            }
            else
            {
                CanGetPatent = true;

                // Проверяем необходимость получения патента
                if (IsHighlyQualified || IsRelocationParticipant)
                {
                    NeedsPatent = false;
                }
                else
                {
                    NeedsPatent = true;
                }
            }
        }

        public void GenerateSteps()
        {
            if (!CanGetPatent)
            {
                Steps.Add("Граждане вашей страны не могут получить патент.");
                return;
            }

            if (!NeedsPatent)
            {
                Steps.Add("Получение патента не требуется, так как вы освобождены.");
                return;
            }

            Steps.Add("1. Обратитесь в УМВД России или в ФГУП \"ПВС\" МВД России для получения патента в течение 30 дней с момента въезда на территорию РФ.");
            Steps.Add("2. Трудоустройтесь и заключите трудовой договор или договор гражданско-правового характера в течение 2 месяцев с момента выдачи патента.");
            Steps.Add("3. Уведомите территориальный орган МВД России об осуществлении трудовой деятельности. Приложите копию трудового договора или договора гражданско-правового характера в течение 2 месяцев с момента выдачи патента.");
        }
    }
}

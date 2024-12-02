using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class Roadmap
    {
        public string Country { get; set; }
        public bool IsHighlyQualified { get; set; }
        public bool IsRelocationParticipant { get; set; }
        public bool NeedsPatent { get; private set; }
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
                "Таджикистан",
                "Узбекистан",
                "Молдова",
                "Украина"
            };

            // Проверяем необходимость патента
            if (exemptCountries.Contains(Country) && (IsHighlyQualified || IsRelocationParticipant))
            {
                NeedsPatent = false;
            }
            else
            {
                NeedsPatent = true;
            }
        }

        public void GenerateSteps()
        {
            if (!NeedsPatent)
            {
                Steps.Add("Патент получать не нужно, так как выполняются условия освобождения.");
                return;
            }

            Steps.Add("Получение патента [в течение 30 дней после въезда на территорию РФ]");
            Steps.Add("Заключение трудового договора или договора гражданско-правового характера [в течение 2 месяцев после получения патента]");
            Steps.Add("Уведомление МВД об осуществлении трудовой деятельности [в течение 2 месяцев после получения патента]");
        }
    }
}

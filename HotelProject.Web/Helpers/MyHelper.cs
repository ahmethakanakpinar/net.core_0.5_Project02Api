namespace HotelProject.Web.Helpers
{
    public class MyHelper
    {

        
            public static string DefaultImage(string input)
            {
                if (input == null || input == "")
                {
                    return "pic-1.png";
                }
                else
                {
                    return input;
                }

            }
            public static string CalculateTimeAgo(DateTime messageDate)
            {
                TimeSpan timeDifference = DateTime.Now - messageDate;

                if (timeDifference.TotalMinutes < 1)
                {
                    return "Şimdi";
                }
                else if (timeDifference.TotalMinutes < 60)
                {
                    int minutesAgo = (int)timeDifference.TotalMinutes;
                    return $"{minutesAgo} Dakika Önce";
                }
                else if (timeDifference.TotalHours < 24)
                {
                    int hoursAgo = (int)timeDifference.TotalHours;
                    return $"{hoursAgo} Saat Önce";
                }
                else
                {
                    return messageDate.ToShortDateString();
                }
            }

    }
}

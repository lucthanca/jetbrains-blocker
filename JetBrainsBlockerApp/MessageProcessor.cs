
namespace Vadu
{
    public class MessageProcessor
    {
        public static string GetMessage(int newRules, int updatedRules, int deleted)
        {
            if (newRules == 0 && updatedRules == 0 && deleted == 0)
            {
                return "No new rule affected!";
            }
            string message = "";
            if (newRules > 0)
            {
                message += $"Create new {newRules} rule(s)";
            }
            if (updatedRules > 0)
            {
                message += $", update {updatedRules} rule(s)";
            }
            if (deleted > 0)
            {
                message += $", delete {deleted} rule(s)";
            }
            if (message.StartsWith(","))
            {
                message = char.ToUpper(message[2]) + message[3..];
            }
            return message;
        }
    }
}

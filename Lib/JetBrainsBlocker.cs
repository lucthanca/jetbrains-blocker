using System.Net;
using WindowsFirewallHelper;
using WindowsFirewallHelper.Addresses;


namespace Vadu
{
    public class JetBrainsBlocker
    {
        // define block return status enum
        public enum BlockStatus
        {
            Success,
            AlreadyBlocked
        }
        private static string _ruleName = @"JetBrainsBlocker";
        private static string _blockUrl = "account.jetbrains.com";

        public static BlockStatus Block(string execFilePath)
        {
            var execFileName = Path.GetFileName(execFilePath.ToString());
            // build rule name
            string ruleName = BuildRuleName(execFileName);
            // find rule by ruleName
            var rule = FirewallManager.Instance.Rules.FirstOrDefault(r => r.Name == ruleName);
            if (rule == null)
            {
                // create a new rule
                var newAppRule = FirewallManager.Instance.CreateApplicationRule(
                    // ensure this rule is applied to all profiles
                    FirewallProfiles.Private | FirewallProfiles.Public | FirewallProfiles.Domain,
                    // give it a name 
                    ruleName,
                    // block rider
                    FirewallAction.Block,
                    // set the path to the rider executable
                    execFilePath
                );

                // add IP addresses to block

                newAppRule.RemoteAddresses = GetBlockAddresses();
                newAppRule.Direction = FirewallDirection.Outbound;
                FirewallManager.Instance.Rules.Add(newAppRule);
                return BlockStatus.Success;
            }
            else
            {
                rule.RemoteAddresses = GetBlockAddresses();
                return BlockStatus.AlreadyBlocked;
            }
        }

        /// <summary>
        /// Clean all rules that are not in list box
        /// </summary>
        /// <param name="inListBoxPaths"></param>
        /// <returns></returns>
        public static int Clean(string[] inListBoxPaths)
        {
            // map in list box paths to take only file name
            var execRuleNames = inListBoxPaths.Select(p => BuildRuleName(Path.GetFileName(p))).ToArray();
            var rules = FirewallManager.Instance.Rules.Where(r => r.Name.StartsWith(_ruleName) && !execRuleNames.Contains(r.Name));
            var rulesCount = rules.Count();
            foreach (var rule in rules)
            {
                FirewallManager.Instance.Rules.Remove(rule);
            }
            return rulesCount;
        }

        private static string BuildRuleName(string execFileName)
        {
            return _ruleName + "[" + execFileName + "]";
        }

        static IAddress[] GetBlockAddresses()
        {
            IPAddress[] ipAddresses = GetIPs();
            IAddress[] addresses = new IAddress[ipAddresses.Length];
            for (int i = 0; i < ipAddresses.Length; i++)
            {
                addresses[i] = new SingleIP(ipAddresses[i]);
            }

            return addresses;
        }

        static IPAddress[] GetIPs()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(_blockUrl);
            return hostEntry.AddressList.ToArray();
        }
    }
}

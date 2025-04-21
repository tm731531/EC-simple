using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EC.Utils;

namespace EC.UnitTest.ECUtils
{
    internal class GenUtilsTest
    {



        public static void EncodeSensetiveDataKey()
        {
            var largeKey = GenUtils.GenerateKey(256);
            string value = GenUtils.EncodeSensetiveDataKey(largeKey);
            Console.WriteLine($"value: {value} ");
            Console.WriteLine($"************************");
            Console.WriteLine($"largeKey: {largeKey}");
        }
        public static void DecodeSensetiveDataKey()
        {

            var key = GenUtils.GenerateKey(20);
            var data = "WVZkME1GUkdVWGxWYWtFeFlVaEplRTV0TlUxU1Z6VXhaRVpHYkZrd1pERmFSa3BIV2tabk5GVXdSalJaTVVJMFUxZGtNRTVJVWs1WlZrRjNaVmhrWVZaR1NtdGFWM014WlZoU1JWRXlhRFZOVjBadFl6Tm9kbEl3Y0Voa01sVXpXa1ZXYjJOWVNqVmxhMVozVDBSYWRGb3dlRWRXUlRVeVdWVjRkRk5GV2xsVlYwcDFXVEpTYWxkWWJGWmxWRko2VTFWd2FHSlhjSFZaV0ZaWlkydGplR1ZXVW5SWmJYQlNXbGRLY1U1RVduRlJlbFp5VlVSR1YwMXRkR0ZqUkVsNVlsZE5lRTFHVWtWamFtUnZWbGM1U2xreGNGWlZWMmhxVFRKc1YxSnVhM2RPVlhjd1lsWk9XbVJFVVRWU1ZVWnFZakpLTUdFd1JuTlZSRXBzVFcweFUxVXpValJqTURSNVZWUlNVRlZ1Um1sTmEzUkZZa1JPU2xKc1RsZFhhM1JLVmtoR1Nsa3pTVFZrVkVZd1VsaHNNbUZ0Y3pKYVNHUlhUMFJTVUdKWVVsWldTR3hwVjJ0c1NWUXdUbWhYUkVKRFdrZE9jRlZuUFQwPQ==";
            string value = GenUtils.DecodeSensetiveDataKey(data, key);
            Console.WriteLine($"key: {value} , key: {key}");
        }


    }
}

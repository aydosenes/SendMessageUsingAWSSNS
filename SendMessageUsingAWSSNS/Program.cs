using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System;
using System.Collections.Generic;

namespace SendMessageUsingAWSSNS
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter phone number to send: "); //without country code

            string phoneNumber = Console.ReadLine();
            
            PhoneVerificationBySMS(phoneNumber);

            Console.ReadKey();
        }
        public static void PhoneVerificationBySMS(string phoneNumber)
        {
            var accessIdKey = "";   //your aws account access id
            var secretKey = ""; //your aws account secret key
            var countryCode = "+90";    // your country code
            string info = "Your Verification Code: "; // information

            var verificationCode = new int[4];
            var random = new Random();
            var codeGenerator = new int[4];

            // generates verification code
            for (int i = 0; i < 4; i++)
            {
                codeGenerator[i] = random.Next(0, 9);
                verificationCode[i] = codeGenerator[i];
            }

            var client = new AmazonSimpleNotificationServiceClient(accessIdKey, secretKey, RegionEndpoint.EUCentral1);
            var messageAttributes = new Dictionary<string, MessageAttributeValue>();
            var smsType = new MessageAttributeValue
            {
                DataType = "String",
                StringValue = "Transactional"
            };

            messageAttributes.Add("AWS.SNS.SMS.SMSType", smsType);

            PublishRequest request = new PublishRequest
            {
                Message = info + string.Join("", verificationCode),
                PhoneNumber = countryCode + phoneNumber,
                MessageAttributes = messageAttributes
            };

            client.PublishAsync(request);

            Console.WriteLine("Sent Code: " + request.Message);
            
        }
    }
}

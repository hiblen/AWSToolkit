using System.Collections.Generic;
using System.Linq;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace AwsLibs
{
    public class AwsFacade
    {
        private IAmazonEC2 _client;
        public AwsFacade()
        {
            _client = AWSClientFactory.CreateAmazonEC2Client();
        }

        public List<Instance> GetInstances()
        {
            var instances = new List<Instance>();
            
            var ec2Request = new DescribeInstancesRequest();

            var ec2Response = _client.DescribeInstances(ec2Request);
            foreach (var reservation in ec2Response.Reservations)
            {
                var instance = reservation.Instances.Single();
                instances.Add(instance);
                //var name = instance.Tags.Single(x => x.Key == "Name").Value;
                //sr.WriteLine("{0} {1} {2} {3}", i++, name, instance.State.Name, instance.PublicDnsName);
            }

            return instances;
        }

        public void StopInstance(Instance instance)

        {
            var stopRequest = new StopInstancesRequest(new List<string> { instance.InstanceId });
            var stopResult = _client.StopInstances(stopRequest);
            //var stateChangeList = stopResult.StoppingInstances;
        }

        public void StartInstance(Instance instance)
        {
            var startRequest = new StartInstancesRequest(new List<string> { instance.InstanceId });
            var startResult = _client.StartInstances(startRequest);
            //var stateChangeList = startResult.StartingInstances;
        }
    }
}
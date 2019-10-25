using EmployeeDirectoryServer.Protos;
using FreshMvvm;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeDirectory
{
    public class MainPageModel : FreshBasePageModel
    {
        public ObservableCollection<Employee> EmployeeList { get; set; }
        public MainPageModel()
        {

        }

        public async override void Init(object initData)
        {
            var channel = new Channel("10.0.2.2", 5050, ChannelCredentials.Insecure);
            //var channel = GrpcChannel.("http://10.0.2.2:5050");
            var client = new EmployeeRequests.EmployeeRequestsClient(channel);
            var response = await client.GetEmployeesAsync(new Empty());
            var tempList = new List<Employee>(response.Employee);
            EmployeeList = new ObservableCollection<Employee>(tempList);
            base.Init(initData);
            RaisePropertyChanged(nameof(EmployeeList));
            
        }
    }
}

using System;
using System.Linq;
using ContactServiceGRPC;
using dotNetTips.Utility.Standard.Tester;
using Grpc.Net.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactMSTest.ServiceGRPCTest;

[TestClass]
public class BusinessDepartmentTest
{
    [TestMethod]
    public void ListBusinessDepartmentTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var businessDepartmentServiceClient = new BusinessDepartmentService.BusinessDepartmentServiceClient(channel);
        var listBusinessDepartmentResponse = businessDepartmentServiceClient.ListBusinessDepartment(new ListBusinessDepartmentRequest());

        Assert.IsTrue(listBusinessDepartmentResponse.Success, listBusinessDepartmentResponse.Message);
    }

    [TestMethod]
    public void AddBusinessDepartmentTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var businessDepartmentServiceClient = new BusinessDepartmentService.BusinessDepartmentServiceClient(channel);
        var businessDepartmentModel = new BusinessDepartmentModel()
        {
            Name = "GRPC" + RandomData.GenerateWord(150),
            Description = "GRPC" + RandomData.GenerateWord(250)
        };
        AddBusinessDepartmentResponse addBusinessDepartmentResponse = businessDepartmentServiceClient.AddBusinessDepartment(new AddBusinessDepartmentRequest() { BusinessDepartmentModel = businessDepartmentModel });

        Assert.IsTrue(addBusinessDepartmentResponse.Success, addBusinessDepartmentResponse.Message);
    }

    [TestMethod]
    public void EditBusinessDepartmentTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var businessDepartmentServiceClient = new BusinessDepartmentService.BusinessDepartmentServiceClient(channel);
        ListBusinessDepartmentResponse listBusinessDepartmentResponse = businessDepartmentServiceClient.ListBusinessDepartment(new ListBusinessDepartmentRequest());
        var businessDepartmentModelEdit = listBusinessDepartmentResponse.ResultItem.LastOrDefault();
        if (businessDepartmentModelEdit is null)
        {
            businessDepartmentModelEdit = new BusinessDepartmentModel();
        }
        businessDepartmentModelEdit.Name = "GRPC 2" + RandomData.GenerateWord(150);
        businessDepartmentModelEdit.Description = "GRPC 2" + RandomData.GenerateWord(250);
        var editaBusinessDepartmentResponse = businessDepartmentServiceClient.EditBusinessDepartment(new EditBusinessDepartmentRequest() { BusinessDepartmentModel = businessDepartmentModelEdit });

        Assert.IsTrue(editaBusinessDepartmentResponse.Success, editaBusinessDepartmentResponse.Message);
    }

    [TestMethod]
    public void DeleteBusinessDepartmentTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var businessDepartmentServiceClient = new BusinessDepartmentService.BusinessDepartmentServiceClient(channel);
        ListBusinessDepartmentResponse listBusinessDepartmentResponse = businessDepartmentServiceClient.ListBusinessDepartment(new ListBusinessDepartmentRequest());
        var businessDepartmentModelDelete = listBusinessDepartmentResponse.ResultItem.LastOrDefault();
        if (businessDepartmentModelDelete is null)
        {
            businessDepartmentModelDelete = new BusinessDepartmentModel();
        }
        DeleteBusinessDepartmentResponse deleteBusinessDepartmentResponse = businessDepartmentServiceClient.DeleteBusinessDepartment(new DeleteBusinessDepartmentRequest(){BusinessDepartmentModel = businessDepartmentModelDelete });

        Assert.IsTrue(deleteBusinessDepartmentResponse.Success, deleteBusinessDepartmentResponse.Message);
    }
}
using System.Linq;
using ContactServiceGRPC;
using dotNetTips.Utility.Standard.Tester;
using Grpc.Net.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactMSTest.ServiceGRPCTest;

[TestClass]
public class BusinessPositionTest
{
    [TestMethod]
    public void ListBusinessPositionTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var businessPositionServiceClient = new BusinessPositionService.BusinessPositionServiceClient(channel);
        var listBusinessPositionResponse = businessPositionServiceClient.ListBusinessPosition(new ListBusinessPositionRequest());

        Assert.IsTrue(listBusinessPositionResponse.Success, listBusinessPositionResponse.Message);
    }

    [TestMethod]
    public void AddBusinessPositionTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var businessPositionServiceClient = new BusinessPositionService.BusinessPositionServiceClient(channel);
        var businessPositionModel = new BusinessPositionModel()
        {
            Name = "GRPC" + RandomData.GenerateWord(150),
            Description = "GRPC" + RandomData.GenerateWord(250)
        };
        AddBusinessPositionResponse addBusinessPositionResponse = businessPositionServiceClient.AddBusinessPosition(new AddBusinessPositionRequest() { BusinessPositionModel = businessPositionModel });

        Assert.IsTrue(addBusinessPositionResponse.Success, addBusinessPositionResponse.Message);
    }

    [TestMethod]
    public void EditBusinessPositionTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var businessPositionServiceClient = new BusinessPositionService.BusinessPositionServiceClient(channel);
        ListBusinessPositionResponse listBusinessPositionResponse = businessPositionServiceClient.ListBusinessPosition(new ListBusinessPositionRequest());
        var businessPositionModelEdit = listBusinessPositionResponse.ResultItem.LastOrDefault();
        if (businessPositionModelEdit is null)
        {
            businessPositionModelEdit = new BusinessPositionModel();
        }
        businessPositionModelEdit.Name = "GRPC 2" + RandomData.GenerateWord(150);
        businessPositionModelEdit.Description = "GRPC 2" + RandomData.GenerateWord(250);
        var editaBusinessPositionResponse = businessPositionServiceClient.EditBusinessPosition(new EditBusinessPositionRequest() { BusinessPositionModel = businessPositionModelEdit });

        Assert.IsTrue(editaBusinessPositionResponse.Success, editaBusinessPositionResponse.Message);
    }

    [TestMethod]
    public void DeleteBusinessPositionTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var businessPositionServiceClient = new BusinessPositionService.BusinessPositionServiceClient(channel);
        ListBusinessPositionResponse listBusinessPositionResponse = businessPositionServiceClient.ListBusinessPosition(new ListBusinessPositionRequest());
        var businessPositionModelDelete = listBusinessPositionResponse.ResultItem.LastOrDefault();
        if (businessPositionModelDelete is null)
        {
            businessPositionModelDelete = new BusinessPositionModel();
        }
        DeleteBusinessPositionResponse deleteBusinessPositionResponse = businessPositionServiceClient.DeleteBusinessPosition(new DeleteBusinessPositionRequest(){BusinessPositionModel = businessPositionModelDelete });

        Assert.IsTrue(deleteBusinessPositionResponse.Success, deleteBusinessPositionResponse.Message);
    }
}
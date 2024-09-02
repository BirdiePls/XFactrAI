using System;
using System.Collections.Generic;
using System.Linq;
using XFactrAI.Models;

public class ServiceRequestRepository : IServiceRequestRepository
{
    private static readonly List<ServiceRequest> serviceRequests = new List<ServiceRequest>();

    public IEnumerable<ServiceRequest> GetAll()
    {
        return serviceRequests;
    }

    public ServiceRequest GetById(string id)
    {
        return serviceRequests.FirstOrDefault(r => r.Id == id);
    }

    public void Add(ServiceRequest request)
    {
        request.Id = serviceRequests.Count > 0 ? (serviceRequests.Max(r => int.Parse(r.Id)) + 1).ToString() : "1";
        request.CreatedDate = DateTime.UtcNow; 
        request.LastModifiedDate = DateTime.UtcNow;
        serviceRequests.Add(request);
    }

    public void Update(ServiceRequest request)
    {
        var existingRequest = serviceRequests.FirstOrDefault(r => r.Id == request.Id);

        if (existingRequest != null)
        {
            existingRequest.BuildingCode = request.BuildingCode;
            existingRequest.Description = request.Description;
            existingRequest.CurrentStatus = request.CurrentStatus; 
            existingRequest.CreatedBy = request.CreatedBy;
            existingRequest.CreatedDate = existingRequest.CreatedDate; 
            existingRequest.LastModifiedBy = request.LastModifiedBy;
            existingRequest.LastModifiedDate = DateTime.UtcNow; 
        }
    }

    public void Delete(string id)
    {
        var request = serviceRequests.FirstOrDefault(r => r.Id == id);
        if (request != null)
        {
            serviceRequests.Remove(request);
        }
    }
}

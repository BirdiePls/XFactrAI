using XFactrAI.Models;

public interface IServiceRequestRepository
{
    IEnumerable<ServiceRequest> GetAll();
    ServiceRequest GetById(string id);
    void Add(ServiceRequest request);
    void Update(ServiceRequest request);
    void Delete(string id);
}

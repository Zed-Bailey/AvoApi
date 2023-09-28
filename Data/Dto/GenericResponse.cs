namespace AvoApi.Data.Dto;

public class GenericResponse
{
    public string Status { get; set; }
    public object Data { get; set; }

    public static GenericResponse Error(string message)
    {
        return new GenericResponse
        {
            Data = new
            {
                message
            },
            Status = "Error"
        };
    }
    
    public static GenericResponse Generic(string status, object data)
    {
        return new GenericResponse
        {
            Data = data,
            Status = status
        };
    }
    
    public static GenericResponse Success(object data)
    {
        return new GenericResponse
        {
            Data = data,
            Status = "Success"
        };
    }
}
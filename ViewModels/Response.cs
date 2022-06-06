namespace Income_Expense_Manager.ViewModels;

public class Response<T>
{
    private List<IncomeCategoryViewModel> category;

    public Response(T data)
    {
        Data = data;
    }

    public T Data { get; set; }
}
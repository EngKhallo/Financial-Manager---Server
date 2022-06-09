using Income_Expense_Manager.Models;

namespace Income_Expense_Manager.ViewModels;

public class Response<T>
{
    private List<IncomeCategoryViewModel> category;
    private List<Income> incomes;
    private List<Expense> expenses;

    public Response(T data)
    {
        Data = data;
    }

    public Response(List<Income> incomes)
    {
        this.incomes = incomes;
    }

    public Response(List<Expense> expenses)
    {
        this.expenses = expenses;
    }

    public T Data { get; set; }
}
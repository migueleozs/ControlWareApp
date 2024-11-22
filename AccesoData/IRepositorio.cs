namespace AccesoData
{
    public interface IRepositorio<T>
    {
       void getItems();
       void addItems();
       void removeItems();
       void updateItems();

    }
}
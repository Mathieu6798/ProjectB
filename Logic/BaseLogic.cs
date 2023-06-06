public abstract class BasicLogic<T> where T : IModel
{
    public abstract void UpdateList(T acc);
    public static List<T> _items;
    public T GetById(int id)
    {
        return _items.Find(x => x.Id == id);
    }
}
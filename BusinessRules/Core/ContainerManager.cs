using StructureMap;

namespace BusinessRules.Core
{
    public class ContainerManager
    {
        private static Container _container;

        public  static Container InitialiseContainer()
        {
            _container = new Container(c =>
            {
                c.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                });
            });
            return _container;
        }

        public static Container GetContainer()
        {
            if (_container == null)
                InitialiseContainer();
            return _container;
        }

        public static T GetInstance<T>()
        {
            return GetContainer().GetInstance<T>();
        }
    }
}

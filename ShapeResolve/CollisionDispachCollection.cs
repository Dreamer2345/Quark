using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuarkPhysicsEngine.Collision.manafold;
using QuarkPhysicsEngine.Shapes;
namespace QuarkPhysicsEngine.ShapeResolve
{
    delegate void DispachDelegate(Manafold manafold);
    class CollisionDispachCollection
    {
        static Dictionary<Tuple<Type,Type>, DispachDelegate> valuePairs = new Dictionary<Tuple<Type,Type>, DispachDelegate>();

        public static void AddDispach<T, T1>(T shape1, T1 shape2, DispachDelegate action) where T : Shape where T1 : Shape
        {
            if (valuePairs.ContainsKey(new Tuple<Type, Type>(shape1.GetType(), shape2.GetType())))
                return;

            valuePairs.Add(new Tuple<Type, Type>(shape1.GetType(), shape2.GetType()), action);
        }
        public static void RunDispach(Manafold manafold,Shape shape1, Shape shape2)
        {
            if (!valuePairs.ContainsKey(new Tuple<Type, Type>(shape1.GetType(), shape2.GetType())))
                throw new Exception("Unresolvable Collision between types"+ shape1.GetType().Name +" and "+shape2.GetType().Name);

            valuePairs[new Tuple<Type, Type>(shape1.GetType(), shape2.GetType())]?.Invoke(manafold);
        }
    }
}

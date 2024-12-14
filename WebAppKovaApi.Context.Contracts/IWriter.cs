using System.Diagnostics.CodeAnalysis;

namespace WebAppKovaApi.Context.Contracts
{
    public interface IWriter
    {
        /// <summary>
        /// 
        /// </summary>
        void Add<IEntity> ([NotNull]IEntity entity) where IEntity : class;

        /// <summary>
        /// 
        /// </summary>
        void Update<IEntity>([NotNull] IEntity entity) where IEntity : class;

        /// <summary>
        /// 
        /// </summary>
        void Delete<IEntity>([NotNull] IEntity entity) where IEntity : class;
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppKovaApi.Context.Contracts
{
    public interface IDbWrider
    {
        public interface IDbWrider<in TEntity> where TEntity : class
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="entity"></param>
            void Add([NotNull] TEntity entity);

            /// <summary>
            /// 
            /// </summary>
            /// <param name="entity"></param>
            void Update([NotNull] TEntity entity);
            
            /// <summary>
            /// 
            /// </summary>
            /// <param name="entity"></param>
            void Delete([NotNull] TEntity entity);
        }
    }
}

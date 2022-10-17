using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Mvvm.Observable
{
    public abstract class EntityViewModel<TEntity> : ObservableObject
        where TEntity : class
    {
        private readonly TEntity _entity;
        
        public EntityViewModel(TEntity entity)
        {
            _entity = entity;
        }

        protected TEntity Entity
        {
            get
            {
                return _entity;
            }
        }
    }
}

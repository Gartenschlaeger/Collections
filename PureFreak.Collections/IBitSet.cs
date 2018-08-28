namespace PureFreak.Collections
{
    public interface IBitSet
    {
        #region Methods

        void Set(int index, bool value);

        void SetAll(bool value);

        bool IsSet(int index);

        void Invert();

        bool[] ToArray();

        #endregion

        #region Properties

        int Capacity { get; }

        #endregion
    }
}
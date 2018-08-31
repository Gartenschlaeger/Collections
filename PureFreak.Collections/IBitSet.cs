namespace PureFreak.Collections
{
    /// <summary>
    /// Represents an dynamic array of bits.
    /// </summary>
    public interface IBitSet
    {
        #region Methods

        /// <summary>
        /// Sets the status of the given bit index.
        /// </summary>
        /// <param name="index">Index of bit to set.</param>
        /// <param name="status">Status of bit.</param>
        void Set(int index, bool status);

        /// <summary>
        /// Sets all bits to the given status.
        /// </summary>
        /// <param name="status">Status to set.</param>
        void SetAll(bool status);

        /// <summary>
        /// Checks if the bit at the given index is set.
        /// </summary>
        /// <param name="index">Index of the bit to check.</param>
        /// <returns>True if the bit is set.</returns>
        bool IsSet(int index);

        /// <summary>
        /// Inverts the status of all bits. 
        /// True to False and False to True.
        /// </summary>
        void Invert();

        /// <summary>
        /// Returns an boolean array representing the bit array.
        /// </summary>
        /// <returns>Array of boleans.</returns>
        bool[] ToArray();

        #endregion

        #region Properties

        /// <summary>
        /// The current capacity of the buffer.
        /// </summary>
        int Capacity { get; }

        #endregion
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DelegatePlotCommand.cs" company="OxyPlot">
//   Copyright (c) 2014 OxyPlot contributors
// </copyright>
// <summary>
//   Provides a controller command for the <see cref="IPlotView" /> implemented by a delegate.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OxyPlot
{
    using System;

    /// <summary>
    /// Provides a controller command for the <see cref="IPlotView" /> implemented by a delegate.
    /// </summary>
    public class MouseDownManipulatorPlotCommand : IViewCommand<OxyMouseDownEventArgs>
    {
        readonly Func<IPlotView, MouseManipulator> factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegatePlotCommand{T}" /> class.
        /// </summary>
        /// <param name="plotManipulatorFactory">The plot manipulator.</param>
        public MouseDownManipulatorPlotCommand(Func<IPlotView, MouseManipulator> plotManipulatorFactory)
        {
            this.factory = plotManipulatorFactory;
        }

        /// <inheritdoc/>
        public void Execute(IView view, IController controller, OxyMouseDownEventArgs args)
        {
            controller.AddMouseManipulator(view, this.factory((IPlotView)view), args);
        }

        /// <inheritdoc/>
        public void Execute(IView view, IController controller, OxyInputEventArgs args)
        {
            controller.AddMouseManipulator(view, this.factory((IPlotView)view), (OxyMouseDownEventArgs)args);
        }
    }
}

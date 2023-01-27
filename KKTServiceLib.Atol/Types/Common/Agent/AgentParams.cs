#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using KKTServiceLib.Atol.Types.Enums;
using KKTServiceLib.Shared.Helpers;
using KKTServiceLib.Shared.Resources;
using KKTServiceLib.Shared.Types.ValidationAttributes;

#endregion

namespace KKTServiceLib.Atol.Types.Common.Agent
{
    [Description("Данные агента")]
    public class AgentParams : IValidatableObject
    {
        /// <summary>
        /// Данные агента
        /// </summary>
        /// <param name="agents">Типы агентов</param>
        public AgentParams(ISet<AgentType> agents)
        {
            if (agents?.Any() != true)
            {
                throw new ArgumentException(string.Format(ErrorStrings.ResourceManager.GetString("MinLengthError"),
                        GetType().GetProperty(nameof(Agents)).GetDisplayName(), 1),
                    nameof(agents));
            }

            Agents = agents;
        }

        /// <summary>
        /// Агенты
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле</item>
        /// <item>Минимальное кол-во элементов: 1</item>
        /// </list>
        [Display(Name = "Агенты")]
        [MinLength(1, ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "MinLengthError")]
        [Required(ErrorMessageResourceType = typeof(ErrorStrings), ErrorMessageResourceName = "RequiredError")]
        public ISet<AgentType> Agents { get; }

        /// <summary>
        /// Данные платежного агента
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если коллекция агентов содержит любой из следующих агентов: <see cref="AgentType.BankPayingAgent"/>, <see cref="AgentType.BankPayingSubagent"/>, <see cref="AgentType.PayingAgent"/>, <see cref="AgentType.PayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные платежного агента")]
        public PayingAgentParams PayingAgent { get; set; }

        /// <summary>
        /// Данные оператора по приему платежей
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если коллекция агентов содержит <see cref="AgentType.PayingAgent"/> или <see cref="AgentType.PayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные оператора по приему платежей")]
        public ReceivePaymentsOperatorParams ReceivePaymentsOperator { get; set; }

        /// <summary>
        /// Данные оператора перевода
        /// </summary>
        /// <list type="bullet">
        /// <item>Обязательное поле, если коллекция агентов содержит <see cref="AgentType.BankPayingAgent"/> или <see cref="AgentType.BankPayingSubagent"/>. В остальных случаях должно отсутствовать</item>
        /// </list>
        [ComplexObjectValidation(ErrorMessageResourceType = typeof(ErrorStrings),
            ErrorMessageResourceName = "ComplexObjectValidationError")]
        [Display(Name = "Данные оператора перевода")]
        public MoneyTransferOperatorParams MoneyTransferOperator { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Agents?.Any() == true)
            {
                if (Agents.Contains(AgentType.BankPayingAgent) ||
                    Agents.Contains(AgentType.BankPayingSubagent) ||
                    Agents.Contains(AgentType.PayingAgent) ||
                    Agents.Contains(AgentType.PayingSubagent))
                {
                    if (PayingAgent == null)
                    {
                        yield return new ValidationResult(string.Format(
                                ErrorStrings.ResourceManager.GetString("RequiredError"),
                                GetType().GetProperty(nameof(PayingAgent)).GetDisplayName()),
                            new[] { nameof(PayingAgent) });
                    }
                }
                else
                {
                    if (PayingAgent != null)
                    {
                        yield return new ValidationResult(string.Format(
                                ErrorStrings.ResourceManager.GetString("MustBeNullError"),
                                GetType().GetProperty(nameof(PayingAgent)).GetDisplayName()),
                            new[] { nameof(PayingAgent) });
                    }
                }

                if (Agents.Contains(AgentType.BankPayingAgent) ||
                    Agents.Contains(AgentType.BankPayingSubagent))
                {
                    if (MoneyTransferOperator == null)
                    {
                        yield return new ValidationResult(string.Format(
                                ErrorStrings.ResourceManager.GetString("RequiredError"),
                                GetType().GetProperty(nameof(MoneyTransferOperator)).GetDisplayName()),
                            new[] { nameof(MoneyTransferOperator) });
                    }
                }
                else
                {
                    if (MoneyTransferOperator != null)
                    {
                        yield return new ValidationResult(string.Format(
                                ErrorStrings.ResourceManager.GetString("MustBeNullError"),
                                GetType().GetProperty(nameof(MoneyTransferOperator)).GetDisplayName()),
                            new[] { nameof(MoneyTransferOperator) });
                    }
                }

                if (Agents.Contains(AgentType.PayingAgent) ||
                    Agents.Contains(AgentType.PayingSubagent))
                {
                    if (ReceivePaymentsOperator == null)
                    {
                        yield return new ValidationResult(string.Format(
                                ErrorStrings.ResourceManager.GetString("RequiredError"),
                                GetType().GetProperty(nameof(ReceivePaymentsOperator)).GetDisplayName()),
                            new[] { nameof(ReceivePaymentsOperator) });
                    }
                }
                else
                {
                    if (ReceivePaymentsOperator != null)
                    {
                        yield return new ValidationResult(string.Format(
                                ErrorStrings.ResourceManager.GetString("MustBeNullError"),
                                GetType().GetProperty(nameof(ReceivePaymentsOperator)).GetDisplayName()),
                            new[] { nameof(ReceivePaymentsOperator) });
                    }
                }
            }
        }
    }
}
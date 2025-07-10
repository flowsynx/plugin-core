namespace FlowSynx.PluginCore;

/// <summary>
/// Defines the logical categorization or role of a plugin within the system.
/// </summary>
public enum PluginCategory
{
    /// <summary>
    /// Plugins that offer artificial intelligence capabilities
    /// such as computer vision, natural language processing, or reasoning engines.
    /// </summary>
    AI,

    /// <summary>
    /// Plugins that provide or consume Application Programming Interfaces (APIs),
    /// including REST, GraphQL, or RPC-based services.
    /// </summary>
    Api,

    /// <summary>
    /// Plugins that handle identity and access management (IAM), SSO, OAuth,
    /// or multi-factor authentication services.
    /// </summary>
    Authentication,

    /// <summary>
    /// Plugins that help in collecting, analyzing, and visualizing
    /// business data to support decision-making.
    /// </summary>
    BusinessIntelligence,

    /// <summary>
    /// Plugins that specifically target blockchain protocols, nodes,
    /// ledger manipulation, or tokenomics, beyond just Web3.
    /// </summary>
    Blockchain,

    /// <summary>
    /// Plugins that enable integration with cloud service providers
    /// such as AWS, Azure, Google Cloud, and others.
    /// </summary>
    Cloud,

    /// <summary>
    /// Plugins that handle messaging, chat, email, VoIP, SMS,
    /// or other communication protocols and services.
    /// </summary>
    Communication,

    /// <summary>
    /// Plugins for data processing, transformation, pipelines,
    /// and data flow orchestration.
    /// </summary>
    Data,

    /// <summary>
    /// Plugins that provide access to or manage relational and non-relational
    /// database systems like PostgreSQL, MySQL, MongoDB, etc.
    /// </summary>
    Database,

    /// <summary>
    /// Plugins that assist with infrastructure automation, CI/CD pipelines,
    /// configuration management, and deployment tooling.
    /// </summary>
    DevOps,

    /// <summary>
    /// Plugins related to financial systems, transactions, accounting,
    /// billing, and related computations.
    /// </summary>
    Finance,

    /// <summary>
    /// Plugins that implement or assist with machine learning workflows,
    /// including model training, evaluation, and prediction.
    /// </summary>
    ML,

    /// <summary>
    /// Plugins that observe the health, performance, and uptime
    /// of applications and infrastructure.
    /// </summary>
    Monitoring,

    /// <summary>
    /// Plugins that capture logs, aggregate them, parse,
    /// and send them to external logging systems or dashboards.
    /// </summary>
    Logging,

    /// <summary>
    /// Plugins that support network operations, diagnostics,
    /// connectivity, DNS, routing, firewalls, and load balancers.
    /// </summary>
    Networking,

    /// <summary>
    /// Plugins that support task management, project planning,
    /// issue tracking, or general workflow automation.
    /// </summary>
    ProjectWorkflow,

    /// <summary>
    /// Plugins for managing company resources such as HR, inventory,
    /// scheduling, budgeting, or operations planning.
    /// </summary>
    ResourcePlanning,

    /// <summary>
    /// Plugins that enhance security features such as encryption,
    /// vulnerability scanning, firewalls, or threat detection.
    /// </summary>
    Security,

    /// <summary>
    /// Plugins for file storage, blob storage, object storage,
    /// or distributed storage systems.
    /// </summary>
    Storage,

    /// <summary>
    /// Plugins that run or support automated and manual tests,
    /// including unit, integration, and end-to-end testing tools.
    /// </summary>
    Testing,

    /// <summary>
    /// Plugins that build and serve websites or web applications,
    /// including frontend and backend frameworks.
    /// </summary>
    Web,

    /// <summary>
    /// Plugins that provide control-flow constructs for workflows,  
    /// such as conditional branching, loops, parallel execution, and event-driven triggers.  
    /// These plugins are used to control the execution logic of workflow tasks.  
    /// </summary>
    ControlFlow
}

namespace FlowSynx.PluginCore;

public static class PluginCategories
{
    public static readonly PluginCategory WebApiIntegration = PluginCategory.Create(
        id: "web-api",
        title: "Web & API Plugins",
        description: "Plugins for web services and API integrations");

    public static readonly PluginCategory CloudPlatformIntegration = PluginCategory.Create(
        id: "cloud",
        title: "Cloud Platform Plugins",
        description: "Plugins for integrating with cloud platforms such as AWS, Azure, GCP");

    public static readonly PluginCategory EnterpriseErp = PluginCategory.Create(
        id: "enterprise-erp",
        title: "Enterprise Software & ERP Plugins",
        description: "Plugins for integrating with enterprise and ERP systems");

    public static readonly PluginCategory DataPlatformAndBIIntegration = PluginCategory.Create(
        id: "data-platform-bi",
        title: "Data Platform & BI Plugins",
        description: "Plugins for data platforms and business intelligence tools");

    public static readonly PluginCategory Communication = PluginCategory.Create(
        id: "communication",
        title: "Communication & Collaboration Plugins",
        description: "Plugins for email, messaging, and collaboration tools");

    public static readonly PluginCategory DevOps = PluginCategory.Create(
        id: "devops",
        title: "DevOps & CI/CD Tool Plugins",
        description: "Plugins for DevOps tools and continuous integration/delivery systems");

    public static readonly PluginCategory ProjectWorkflow = PluginCategory.Create(
        id: "project-workflow",
        title: "Project & Workflow Management Plugins",
        description: "Plugins for project tracking and workflow management systems");

    public static readonly PluginCategory StorageTransfer = PluginCategory.Create(
        id: "storage-transfer",
        title: "Storage & File Transfer Plugins",
        description: "Plugins for file storage, transfer, and synchronization");

    public static readonly PluginCategory IdentityAuth = PluginCategory.Create(
        id: "identity-auth",
        title: "Identity & Authentication Plugins",
        description: "Plugins for identity management and authentication services");

    public static readonly PluginCategory AIML = PluginCategory.Create(
        id: "ai-ml",
        title: "AI & ML Plugins",
        description: "Plugins for integrating artificial intelligence and machine learning services");

    public static readonly PluginCategory Monitoring = PluginCategory.Create(
        id: "monitoring",
        title: "Monitoring, Observability & Logging Plugins",
        description: "Plugins for system monitoring, observability, and logging");

    public static readonly PluginCategory TestingQuality = PluginCategory.Create(
        id: "testing-quality",
        title: "Testing & Quality Plugins",
        description: "Plugins for software testing, QA automation, and code quality analysis");

    public static readonly PluginCategory Finance = PluginCategory.Create(
        id: "finance",
        title: "Financial & Payment Plugins",
        description: "Plugins for finance systems and payment gateways");

    public static readonly PluginCategory Blockchain = PluginCategory.Create(
        id: "blockchain",
        title: "Blockchain & Web3 Plugins",
        description: "Plugins for blockchain protocols, crypto wallets, and Web3 services");
}
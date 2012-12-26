[T4Scaffolding.Scaffolder(Description = "This Scaffolder create an API Controller")][CmdletBinding()]
param(        
    [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ApiControllerName,
    [parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,
    [string]$DbContextType,
    [string]$Project,
    [string]$CodeLanguage,
    [string[]]$TemplateFolders,
    [switch]$Force = $false,
	[switch]$Repository = $false,
    [switch]$UseIoC = $false
)

# Ensure you've referenced System.Data.Entity
(Get-Project $Project).Object.References.Add("System.Data.Entity") | Out-Null

$foundModelType = Get-ProjectType $ModelType -Project $Project
if (!$foundModelType) { return }

$primaryKey = Get-PrimaryKey $foundModelType.FullName -Project $Project -ErrorIfNotFound
if (!$primaryKey) { return }

if(!$DbContextType) { $DbContextType = [System.Text.RegularExpressions.Regex]::Replace((Get-Project $Project).Name, "[^a-zA-Z0-9]", "") + "Context" }
		
$outputPath = Join-Path Controllers $ApiControllerName
if ($Area) {
	$areaFolder = Join-Path Areas $Area
	if (-not (Get-ProjectItem $areaFolder -Project $Project)) {
		Write-Error "Cannot find area '$Area'. Make sure it exists already."
		return
	}
	$outputPath = Join-Path $areaFolder $outputPath
}

#if (!$NoChildItems) {
#	$dbContextScaffolderResult = Scaffold DbContext -ModelType $ModelType -DbContextType $DbContextType -Area $Area -Project $Project -CodeLanguage $CodeLanguage
#	$foundDbContextType = $dbContextScaffolderResult.DbContextType
#	if (!$foundDbContextType) { return }
#}
if (!$foundDbContextType) { $foundDbContextType = Get-ProjectType $DbContextType -Project $Project }
if (!$foundDbContextType) { return }

$modelTypePluralized = Get-PluralizedWord $foundModelType.Name
$defaultNamespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value
$repositoryNamespace = [T4Scaffolding.Namespaces]::Normalize($defaultNamespace + "." + [System.IO.Path]::GetDirectoryName($outputPath).Replace([System.IO.Path]::DirectorySeparatorChar, "."))
$modelTypeNamespace = [T4Scaffolding.Namespaces]::GetNamespace($foundModelType.FullName)

#if ($Repository) {
#	if(!$DbContextType) { $DbContextType = [System.Text.RegularExpressions.Regex]::Replace((Get-Project $Project).Name, "[^a-zA-Z0-9]", "") + "Context" }
#	Scaffold Repository -ModelType $ModelType -DbContextType $DbContextType -Project $Project -CodeLanguage $CodeLanguage -Force:$Force -BlockUi
#}

$templateName = if($Repository) { "WebApiWithRepositoryTemplate" } else { "ApiControllerDevmilesTemplate" }
Add-ProjectItemViaTemplate $outputPath -Template $templateName `
	-Model @{
	ModelType = [MarshalByRefObject]$foundModelType; 
	PrimaryKey = [string]$primaryKey; 
	DefaultNamespace = $defaultNamespace; 
	Namespace = $defaultNamespace;
	ApiControllerName = $ApiControllerName;
	UseIoC = [Boolean]$UseIoC;
	RepositoryNamespace = $repositoryNamespace; 
	ModelTypeNamespace = $modelTypeNamespace; 
	ModelTypePluralized = [string]$modelTypePluralized; 
	DbContextNamespace = $foundDbContextType.Namespace.FullName;
	DbContextType = [MarshalByRefObject]$foundDbContextType;
} -SuccessMessage "Added WebApi output at '{0}'" -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -Force:$Force

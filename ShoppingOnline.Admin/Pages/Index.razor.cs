namespace ShoppingOnline.Admin.Pages;

public partial class Index
{
	public bool IsProcessing { get; set; }

	protected override void OnInitialized()
	{
		IsProcessing = true;
		IsProcessing = false;
	}
}
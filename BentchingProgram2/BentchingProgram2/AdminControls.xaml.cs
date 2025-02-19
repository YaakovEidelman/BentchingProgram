using BusinessLogicLayer;
using ViewModel;

namespace BentchingProgram2;

public partial class AdminControls : ContentPage
{

    Dictionary<Border, Grid> navcontentpairs;
    ViewModelBinder _viewmodelbinder;
    public AdminControls(ViewModelBinder viewmodelbinder)
    {
        InitializeComponent();
        _viewmodelbinder = viewmodelbinder;
        this.BindingContext = _viewmodelbinder;
        navcontentpairs = new()
        {
            {Nav_Members, Members },
            {Nav_Years, Years },
            {Nav_Parshas, Parshas }
        };
    }

    private async Task<bool> PromptBeforeDelete(IDeleteable obj, string s)
    {
        return await DisplayAlert(this.ToString(), $"Are you sure you want to delete {s}?", "Yes", "No");
    }
    private async Task DeleteItem(IDeleteable item)
    {
        await item.Delete();
    }
    private void SetPanelAndNav(Border b)
    {
        foreach (KeyValuePair<Border, Grid> kvp in navcontentpairs)
        {
            Label? l = kvp.Key.Content as Label;
            if (kvp.Key == b)
            {
                kvp.Key.BackgroundColor = Color.FromArgb("#007BFF");
                kvp.Value.IsVisible = true;
                if (l != null) l.TextColor = Colors.White;
            }
            else
            {
                kvp.Key.BackgroundColor = Colors.Transparent;
                kvp.Value.IsVisible = false;
                if (l != null) l.TextColor = Color.FromArgb("#333333");
            }
        }
    }

    private void Nav_Tapped(object sender, TappedEventArgs e)
    {
        if (sender is Border)
        {
            Border tappednav = (Border)sender;
            SetPanelAndNav(tappednav);
        }
    }
    private async void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {
        if (sender is Border)
        {
            Border hovnav = (Border)sender;
            await hovnav.ScaleTo(1.1, 100, Easing.CubicInOut);
        }
    }
    private async void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    {
        if (sender is Border hovnav)
        {
            await hovnav.ScaleTo(1.0, 100, Easing.CubicInOut);
        }
    }

    private async void AddMember_Clicked(object sender, EventArgs e)
    {
        if(sender is Button)
        {
            await Navigation.PushModalAsync(new MemberEditPage(_viewmodelbinder));
        } 
        else if (sender is Grid g)
        {
            bizMember m = (bizMember)g.BindingContext;
            await Navigation.PushModalAsync(new MemberEditPage(_viewmodelbinder, m.MemberId, m.FirstName, m.LastName, m.BirthDate, m.AmountPaidUp));
        }
    }
    private async void AddYear_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            await Navigation.PushModalAsync(new YearEditPage(_viewmodelbinder));
        }
        else if (sender is Grid g)
        {
            int i = ((bizEarningYear)g.BindingContext).EarningYearId;
            await Navigation.PushModalAsync(new YearEditPage(_viewmodelbinder, i));
        }
    }
    private async void AddParsha_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            await Navigation.PushModalAsync(new ParshaEditPage(_viewmodelbinder));
        }
        else if (sender is Grid g)
        {
            bizParsha bp = (bizParsha)g.BindingContext;
            await Navigation.PushModalAsync(new ParshaEditPage(_viewmodelbinder, bp.ParshaId, bp.ParshaNameEnglish, bp.ParshaName));
        }
    }
    private async void Delete_Clicked(object sender, EventArgs e)
    {
        if (sender is Button b && b.Parent.BindingContext is IDeleteable context)
        {
            if(await PromptBeforeDelete(context, context.Name))
            {
                try
                {
                    await DeleteItem(context);
                }
                catch (Exception ex)
                {
                    await DisplayAlert(this.ToString(), ex.Message, "Close");
                }
            }
        }
    }

}
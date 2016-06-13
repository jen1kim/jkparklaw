function toogleEnabled(ckb,item)
{

    if ($(ckb).checked == true)
    {
        $(item).disabled = false;
    }
    else
    {
        $(item).disabled = true;
        $(item).value = '';
    }
}
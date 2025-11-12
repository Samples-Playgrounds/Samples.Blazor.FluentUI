namespace Core.Runtime;

///
/// 
/*
    https://stackoverflow.com/questions/53516620/detect-client-or-server-mode
*/
public partial class 
                                        RuntimeMode
{
    public
        bool
                                        IsClientSide 
                                        => 
                                        HasMono;

    public
        bool
                                        IsServerSide 
                                        => 
                                        !HasMono; 

    public 
        bool
                                        HasMono 
                                        => 
                                        System.Type.GetType("Mono.Runtime") != null;
}

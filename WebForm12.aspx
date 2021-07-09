<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="WebForm12.aspx.cs" Inherits="TeknikTakip.WebForm12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="row text-center">
        <h2>Stok Bilgileri Ekle</h2>
    </div>
    <div>
        <label class="col-md-2">Stok Kodu  </label>
        <div class="col-md-9">
            <input type="text" class="form-control" id="stok_kodu" runat="server">
        </div>
        <div class="col-md-1">
            <i class="fa fa-lock fa-2x"></i>
        </div>
    </div>
    <div>
        <label class="col-md-2"> Stok Adı  </label>
        <div class="col-md-9">
            <input type="text" class="form-control" id="stok_adi" runat="server">
        </div>
        <div class="col-md-1">
            <i class="fa fa-lock fa-2x"></i>
        </div>
    </div>
    <div>
        <label class="col-md-2">Birim</label>
        <div class="col-md-9">
            <input class="form-control" runat="server" id="birim">
        </div>
        <div class="col-md-1">
            <i class="fa fa-lock fa-2x"></i>
        </div>
    </div>
    <div>
        <label class="col-md-2">Stok Tip Adı  </label>
        <div class="col-md-9">
            <input class="form-control" runat="server" id="stok_tip_adi">
        </div>
        <div class="col-md-1">
            <i class="fa fa-lock fa-2x"></i>
        </div>
        
    </div>
    <div>
        <div class="col-lg-3">
            <asp:Button ID="Ürün_Bilgi" class="btn btn-info te" Height="40px" Width="200" runat="server" OnClick="Ürün_Bilgi_Click" Text="Ekle" />
        </div>
        <asp:Label ID="Label6" runat="server"></asp:Label>

    </div>
    <div class="col-xs-12">
        <asp:Label ID="id" runat="server"></asp:Label>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-hover text-center">
                    <thead>

                        <th class="  text-center bg-secondary text-white">Seç</th>
                        <th class="  text-center bg-secondary text-white">Id</th>
                        <th class=" text-center  bg-secondary text-white">Stok Kodu</th>
                        <th class=" text-center  bg-secondary text-white">Stok Adı </th>
                        <th class=" text-center  bg-secondary text-white">Birim</th>
                        <th class=" text-center  bg-secondary text-white">Stok Tip Adı</th>  
                        <th class=" text-center  bg-secondary text-white">Kayit Tarihi</th> 
                        <th class=" text-center  bg-secondary text-white">Güncelleme Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Güncelle / Sil</th>

                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td>
                            <asp:LinkButton ID="sec" runat="server" OnClick="sec_Click1" CommandArgument='<%#Eval("Id") %>'>✓</asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("Id") %> '> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Stok_Kodu") %> '> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("Stok_Adi") %> '> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("Birim") %> '> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("Stok_Tip_Adi") %> '> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text='<%#Eval("kayit_tarihi") %> '> </asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text='<%#Eval("güncelle_tarihi")%>'> </asp:Label>
                        </td>
                        <td>
                            <asp:LinkButton ID="Güncelle" title="Güncellemek İçin Tıklayınız" OnClick="Güncelle_Click1" CssClass="fa fa-refresh" runat="server" ></asp:LinkButton>
                            &nbsp;
                           &nbsp;
                            &nbsp;
                            &nbsp;
                          <asp:LinkButton ID="sil" runat="server" title="Silmek İçin Tıklayınız" CssClass="fa fa-trash text-danger text" OnClick="sil_Click" OnClientClick="return confirm('Silmek istiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                           

                        </td>

                    </tr>
                </tbody>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
        </div>
</asp:Content>

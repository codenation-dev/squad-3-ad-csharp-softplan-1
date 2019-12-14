unit uMain;

interface

uses
  System.SysUtils, System.Types, System.UITypes, System.Classes, System.Variants,
  FMX.Types, FMX.Controls, FMX.Forms, FMX.Graphics, FMX.Dialogs, FMX.StdCtrls, FMX.Edit,
  FMX.Controls.Presentation, FMX.ScrollBox, FMX.Memo, IPPeerClient, REST.Client,
  Data.Bind.Components, Data.Bind.ObjectScope;

type


  TForm1 = class(TForm)
    Panel1: TPanel;
    Panel2: TPanel;
    Label1: TLabel;
    edtBaseIrl: TEdit;
    ToolBar1: TToolBar;
    btnLogin: TButton;
    Label2: TLabel;
    edtEMail: TEdit;
    Label3: TLabel;
    edtSenha: TEdit;
    Label4: TLabel;
    edtToken: TEdit;
    Panel3: TPanel;
    edtCodigoUsuario: TEdit;
    edtTokenLog: TEdit;
    btnEnviarErro: TButton;
    Label5: TLabel;
    edtChamada: TEdit;
    Label6: TLabel;
    RESTClient: TRESTClient;
    RESTRequestLogin: TRESTRequest;
    RESTResponseLogin: TRESTResponse;
    Panel4: TPanel;
    mmJsonEnvio: TMemo;
    Panel5: TPanel;
    mmJson: TMemo;
    RESTRequest: TRESTRequest;
    RESTResponse: TRESTResponse;
    procedure btnLoginClick(Sender: TObject);
    procedure btnEnviarErroClick(Sender: TObject);
    procedure RESTRequestLoginHTTPProtocolError(Sender: TCustomRESTRequest);
    procedure RESTRequestHTTPProtocolError(Sender: TCustomRESTRequest);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.fmx}



procedure TForm1.btnEnviarErroClick(Sender: TObject);
var
  sValor: string;
//  i: integer;
begin
//  i := Pos(edtChamada.Text, '/');
//  if i < 1 then
//    i := Length(edtChamada.Text);
  RESTClient.BaseURL := edtBaseIrl.Text + edtChamada.Text;
  Caption := RESTClient.BaseURL;

  sValor := StringReplace(
    StringReplace(mmJsonEnvio.Lines.Text, '{0}', edtCodigoUsuario.Text, [rfReplaceAll]),
    '{1}', edtTokenLog.Text, [rfReplaceAll]);

  mmJson.Lines.Text := sValor;

  RESTRequest.Params[0].Value := sValor;
  RESTRequest.Execute;

  mmJson.Lines.Text := RESTResponse.JSONValue.ToString;


end;

function PegarTextDoJson(const psEntrada, psChave: string): string;
var
  sValor: string;
  nPos, nPos2: integer;
begin
  //procura por
  nPos := Pos('"'+psChave+'":"', psEntrada);
  if nPos > 0 then
  begin
    sValor := Copy(psEntrada, nPos + length('"'+psChave+'":"'), 50);
    nPos2 := Pos('"', sValor);
    if nPos2 > 0 then
    begin
      result := Copy(sValor, 1, nPos2 - 1);
    end;
  end;
end;

function PegarNumeroDoJson(const psEntrada, psChave: string): integer;
var
  sRet, sValor: string;
  i, nPos, nPos2: integer;
begin
  sRet := '';
  //procura por
  nPos := Pos('"'+psChave+'":', psEntrada);
  if nPos > 0 then
  begin
    sValor := Copy(psEntrada, nPos + length('"'+psChave+'":'), 50);
    //anda enquanto for numero
    for i := 1 to length(sValor) do
    begin
      sRet := sRet + Copy(sValor, i, 1);
      if StrToIntDef(sRet, -1) = -1 then
      begin
        Delete(sRet, i, 1);
        break;
      end;
    end;
    result := StrToIntDef(sRet, 0);
  end;
end;


procedure TForm1.btnLoginClick(Sender: TObject);
var
  sValor: string;
begin
  RESTClient.BaseURL := edtBaseIrl.Text + '/auth';
  Caption := RESTClient.BaseURL;

  sValor := Format('{%s"login": "%s",%s"password": "%s"%s}', [#13#10, edtEMail.Text, #13#10, edtSenha.Text, #13#10]);
  //sValor := Format('{"login": "%s", "password": "%s" }', [edtEMail.Text, edtSenha.Text]);
  mmJson.Lines.Text := 'login:'+  sValor;
  RESTRequestLogin.Params[0].Value := sValor;
  RESTRequestLogin.Execute;

  sValor := RESTResponseLogin.JSONValue.ToString;
  mmJson.Lines.Text := sValor;

  edtToken.Text := PegarTextDoJson(sValor, 'access_token');

  edtTokenLog.Text := PegarTextDoJson(sValor, 'token');
  edtCodigoUsuario.Text := PegarNumeroDoJson(sValor, 'id').ToString;
end;

procedure TForm1.RESTRequestHTTPProtocolError(Sender: TCustomRESTRequest);
begin
  mmJson.Lines.Text := 'Erro envio!';
end;

procedure TForm1.RESTRequestLoginHTTPProtocolError(Sender: TCustomRESTRequest);
begin
  mmJson.Lines.Text := 'Erro login!';
end;

end.

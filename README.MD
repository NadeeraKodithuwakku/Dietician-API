# Architecture

This project is an example of architecture using new technologies and best practices.

The goal is to share knowledge and use it as reference for new projects.

Thanks for enjoying!

## Build

[![Build](https://dev.azure.com/rafaelfgx/Architecture/_apis/build/status/Build)](https://dev.azure.com/rafaelfgx/Architecture/_apis/build/status/Build)

## Code Analysis

[![Codacy](https://api.codacy.com/project/badge/Grade/3d1ea5b1f4b745488384c744cb00d51e)](https://api.codacy.com/project/badge/Grade/3d1ea5b1f4b745488384c744cb00d51e)

## Technologies

* [.NET Core 3.1](https://dotnet.microsoft.com/download)
* [ASP.NET Core 3.1](https://docs.microsoft.com/en-us/aspnet/core)
* [Entity Framework Core 3.1](https://docs.microsoft.com/en-us/ef/core)
* [C# 8.0](https://docs.microsoft.com/en-us/dotnet/csharp)
* [Angular 9.1](https://angular.io/docs)
* [Typescript](https://www.typescriptlang.org/docs/home.html)
* [HTML](https://www.w3schools.com/html)
* [CSS](https://www.w3schools.com/css)
* [SASS](https://sass-lang.com)
* [UIkit](https://getuikit.com/docs/introduction)
* [JWT](https://jwt.io)
* [FluentValidation](https://fluentvalidation.net)
* [Scrutor](https://github.com/khellang/Scrutor)
* [Serilog](https://serilog.net)
* [Docker](https://docs.docker.com)
* [Azure DevOps](https://dev.azure.com)

## Practices

* Clean Code
* SOLID Principles
* DDD (Domain-Driven Design)
* Code Analysis
* Separation of Concerns
* Unit of Work Pattern
* Repository Pattern
* Database Migrations
* Authentication
* Authorization
* Performance
* Logging
* DevOps

## Run

<details>
<summary>Command Line</summary>

#### Prerequisites

* [.NET Core SDK](https://aka.ms/dotnet-download)
* [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Steps

1. Open directory **source\Web\Frontend** in command line and execute **npm run restore**.
2. Open directory **source\Web** in command line and execute **dotnet run**.
3. Open <https://localhost:8090>.

</details>

<details>
<summary>Visual Studio Code</summary>

#### Prerequisites

* [.NET Core SDK](https://aka.ms/dotnet-download)
* [SQL Server](https://go.microsoft.com/fwlink/?linkid=866662)
* [Visual Studio Code](https://code.visualstudio.com)
* [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Steps

1. Open directory **source\Web\Frontend** in command line and execute **npm run restore**.
2. Open **source** directory in Visual Studio Code.
3. Press **F5**.

</details>

<details>
<summary>Visual Studio</summary>

#### Prerequisites

* [Visual Studio](https://visualstudio.microsoft.com)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)

#### Steps

1. Open directory **source\Web\Frontend** in command line and execute **npm run restore**.
2. Open **source\Architecture.sln** in Visual Studio.
3. Set **Architecture.Web** as startup project.
4. Press **F5**.

</details>

<details>
<summary>Docker</summary>

#### Prerequisites

* [Docker](https://www.docker.com/get-started)

#### Steps

1. Execute **docker-compose up --build -d --force-recreate** in root directory.
2. Open <http://localhost:8095>.

</details>

## Utils

<details>
<summary>Books</summary>

* **Clean Code: A Handbook of Agile Software Craftsmanship** - Robert C. Martin (Uncle Bob)
* **Clean Architecture: A Craftsman's Guide to Software Structure and Design** - Robert C. Martin (Uncle Bob)
* **Implementing Domain-Driven Design** - Vaughn Vernon
* **Domain-Driven Design Distilled** - Vaughn Vernon
* **Domain-Driven Design: Tackling Complexity in the Heart of Software** - Eric Evans
* **Domain-Driven Design Reference: Definitions and Pattern Summaries** - Eric Evans

</details>

<details>
<summary>Tools</summary>

* [Visual Studio](https://visualstudio.microsoft.com)
* [Visual Studio Code](https://code.visualstudio.com)
* [SQL Server](https://www.microsoft.com/sql-server)
* [Node.js](https://nodejs.org)
* [Angular CLI](https://cli.angular.io)
* [Postman](https://www.getpostman.com)
* [Codacy](https://codacy.com)
* [StackBlitz](https://stackblitz.com)

</details>

<details>
<summary>Visual Studio Extensions</summary>

* [CodeMaid](https://marketplace.visualstudio.com/items?itemName=SteveCadwallader.CodeMaid)
* [ReSharper](https://www.jetbrains.com/resharper)

</details>

<details>
<summary>Visual Studio Code Extensions</summary>

* [Angular Language Service](https://marketplace.visualstudio.com/items?itemName=Angular.ng-template)
* [Angular Snippets](https://marketplace.visualstudio.com/items?itemName=johnpapa.Angular2)
* [Atom One Dark Theme](https://marketplace.visualstudio.com/items?itemName=akamud.vscode-theme-onedark)
* [Bracket Pair Colorizer](https://marketplace.visualstudio.com/items?itemName=CoenraadS.bracket-pair-colorizer)
* [C#](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp)
* [Debugger for Chrome](https://marketplace.visualstudio.com/items?itemName=msjsdiag.debugger-for-chrome)
* [Material Icon Theme](https://marketplace.visualstudio.com/items?itemName=PKief.material-icon-theme)
* [Sort Lines](https://marketplace.visualstudio.com/items?itemName=Tyriar.sort-lines)
* [TSLint](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-typescript-tslint-plugin)
* [Visual Studio Keymap](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vs-keybindings)

</details>

## Nuget Packages

Packages were created to make this architecture clean of common features for any solution.

**Source:** [https://github.com/rafaelfgx/DotNetCore](https://github.com/rafaelfgx/DotNetCore)

**Published:** [https://www.nuget.org/profiles/rafaelfgx](https://www.nuget.org/profiles/rafaelfgx)

## Layers

**Web:** API and Frontend (Angular).

**Application:** Flow control.

**Domain:** Business rules and domain logic.

**Model:** Data transfer objects.

**Database:** Database persistence.

## Web

### Angular

#### Component

The **Component** class is responsible for being a small part of the application.

It must be as simple and small as possible.

```typescript
@Component({ selector: "app-signin", templateUrl: "./signin.component.html" })
export class AppSignInComponent {
    form = this.formBuilder.group({
        login: ["", Validators.required],
        password: ["", Validators.required]
    });

    constructor(
        private readonly formBuilder: FormBuilder,
        private readonly appAuthService: AppAuthService) {
    }

    signIn() {
        this.appAuthService.signIn(this.form.value);
    }
}
```

```html
<form [formGroup]="form">
    <fieldset>
        <div>
            <app-label for="login" text="Login"></app-label>
            <app-input-text formControlName="login" text="Login" [autofocus]="true"></app-input-text>
        </div>
        <div>
            <app-label for="password" text="Password"></app-label>
            <app-input-password formControlName="password" text="Password"></app-input-password>
        </div>
        <div>
            <app-button text="Sign in" [disabled]="form.invalid" (click)="signIn()"></app-button>
        </div>
    </fieldset>
</form>
```

#### Model

The **Model** class is responsible for containing a set of data.

```typescript
export class SignInModel {
    login!: string;
    password!: string;
}
```

#### Service

The **Service** class is responsible for accessing the API or containing logic that does not belong to component.

```typescript
@Injectable({ providedIn: "root" })
export class AppUserService {
    constructor(private readonly http: HttpClient) { }

    add(model: UserModel) {
        return this.http.post<number>("Users", model);
    }

    delete(id: number) {
        return this.http.delete(`Users/${id}`);
    }

    get(id: number) {
        return this.http.get<UserModel>(`Users/${id}`);
    }

    list() {
        return this.http.get<UserModel[]>("Users");
    }

    update(model: UserModel) {
        return this.http.put(`Users/${model.id}`, model);
    }
}
```

#### Guard

The **Guard** class is responsible for route security.

```typescript
@Injectable({ providedIn: "root" })
export class AppRouteGuard implements CanActivate {
    constructor(
        private readonly router: Router,
        private readonly appTokenService: AppTokenService) { }

    canActivate() {
        if (this.appTokenService.any()) { return true; }
        this.router.navigate(["/login"]);
        return false;
    }
}
```

#### Error Handler

The **ErrorHandler** class is responsible for centralizing the management of all errors and exceptions.

```typescript
@Injectable({ providedIn: "root" })
export class AppErrorHandler implements ErrorHandler {
    constructor(private readonly injector: Injector) { }

    handleError(error: any) {
        if (error instanceof HttpErrorResponse) {
            switch (error.status) {
                case 401: {
                    const router = this.injector.get<Router>(Router);
                    router.navigate(["/login"]);
                    return;
                }
                case 422: {
                    const appModalService = this.injector.get<AppModalService>(AppModalService);
                    appModalService.alert(error.error);
                    return;
                }
            }
        }

        console.error(error);
    }
}
```

#### HTTP Interceptor

The **HttpInterceptor** class is responsible for intercepting request and response.

This interceptor adds JWT to header for every request.

```typescript
@Injectable({ providedIn: "root" })
export class AppHttpInterceptor implements HttpInterceptor {
    constructor(private readonly appTokenService: AppTokenService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler) {
        request = request.clone({
            setHeaders: { Authorization: `Bearer ${this.appTokenService.get()}` }
        });

        return next.handle(request);
    }
}
```

#### Routes

The **Routes** constant is responsible for registering all lazy load routes.

```typescript
export const routes: Routes = [
    {
        path: "",
        component: AppParentComponent,
        children: [
            { path: "view1", loadChildren: () => import("./view1.module").then((module) => module.AppView1Module) },
            { path: "view2", loadChildren: () => import("./view2.module").then((module) => module.AppView2Module) }
        ]
    }
];
```

### ASP.NET Core

#### Postman

Import "postman.json" file into Postman.

#### Startup

The **Startup** class is responsible for configuring the API.

```csharp
public class Startup
{
    public void Configure(IApplicationBuilder application)
    {
        application.UseException();
        application.UseCorsAllowAny();
        application.UseHttps();
        application.UseRouting();
        application.UseStaticFiles();
        application.UseResponseCompression();
        application.UseResponseCaching();
        application.UseAuthentication();
        application.UseAuthorization();
        application.UseEndpoints();
        application.UseSpa();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddSecurity();
        services.AddResponseCompression();
        services.AddResponseCaching();
        services.AddControllersDefault();
        services.AddSpa();
        services.AddContext();
        services.AddServices();
    }
}
```

#### Extensions

The **Extensions** class is responsible for adding and configuring services for dependency injection.

```csharp
public static class Extensions
{
    public static void AddContext(this IServiceCollection services)
    {
        var connectionString = services.GetConnectionString(nameof(Context));
        services.AddContextMigrate<Context>(options => options.UseSqlServer(connectionString));
    }

    public static void AddSecurity(this IServiceCollection services)
    {
        services.AddHash(10000, 128);
        services.AddJsonWebToken(Guid.NewGuid().ToString(), TimeSpan.FromHours(12));
        services.AddAuthenticationJwtBearer();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services.AddFileExtensionContentTypeProvider();
        services.AddClassesInterfaces(typeof(IUserService).Assembly);
        services.AddClassesInterfaces(typeof(IUnitOfWork).Assembly);
    }

    public static void AddSpa(this IServiceCollection services)
    {
        services.AddSpaStaticFiles("Frontend/dist");
    }

    public static void UseSpa(this IApplicationBuilder application)
    {
        application.UseSpaAngularServer("Frontend", "development");
    }
}
```

#### Controller

The **Controller** class is responsible for receiving, processing, and responding requests.

It must be as simple and small as possible, without any rule or logic.

```csharp
[ApiController]
[Route("Users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public Task<IActionResult> AddAsync(UserModel model)
    {
        return _userService.AddAsync(model).ResultAsync();
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteAsync(long id)
    {
        return _userService.DeleteAsync(id).ResultAsync();
    }

    [HttpGet("{id}")]
    public Task<IActionResult> GetAsync(long id)
    {
        return _userService.GetAsync(id).ResultAsync();
    }

    [HttpPatch("{id}/Inactivate")]
    public Task InactivateAsync(long id)
    {
        return _userService.InactivateAsync(id);
    }

    [HttpGet("List")]
    public Task<IActionResult> ListAsync([FromQuery]PagedListParameters parameters)
    {
        return _userService.ListAsync(parameters).ResultAsync();
    }

    [HttpGet]
    public Task<IActionResult> ListAsync()
    {
        return _userService.ListAsync().ResultAsync();
    }

    [HttpPut("{id}")]
    public Task<IActionResult> UpdateAsync(UserModel model)
    {
        return _userService.UpdateAsync(model).ResultAsync();
    }
}
```

## Application

#### Service

The **Service** class is responsible for flow control. It uses validator, factory, domain, repository and unit of work, but it does not contain business rules or domain logic.

```csharp
public sealed class UserService : IUserService
{
    private readonly IAuthService _authService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UserService
    (
        IAuthService authService,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository
    )
    {
        _authService = authService;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IResult<long>> AddAsync(UserModel model)
    {
        var validation = await new AddUserModelValidator().ValidateAsync(model);

        if (validation.Failed)
        {
            return Result<long>.Fail(validation.Message);
        }

        var authResult = await _authService.AddAsync(model.Auth);

        if (authResult.Failed)
        {
            return Result<long>.Fail(authResult.Message);
        }

        var user = UserFactory.Create(model, authResult.Data);

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return Result<long>.Success(user.Id);
    }

    public async Task<IResult> DeleteAsync(long id)
    {
        var authId = await _userRepository.GetAuthIdByUserIdAsync(id);

        await _userRepository.DeleteAsync(id);

        await _authService.DeleteAsync(authId);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

    public Task<UserModel> GetAsync(long id)
    {
        return _userRepository.GetByIdAsync(id);
    }

    public async Task InactivateAsync(long id)
    {
        var user = new User(id);

        user.Inactivate();

        await _userRepository.UpdateStatusAsync(user);

        await _unitOfWork.SaveChangesAsync();
    }

    public Task<PagedList<UserModel>> ListAsync(PagedListParameters parameters)
    {
        return _userRepository.Queryable.Select(UserExpression.Model).ListAsync(parameters);
    }

    public async Task<IEnumerable<UserModel>> ListAsync()
    {
        return await _userRepository.Queryable.Select(UserExpression.Model).ToListAsync();
    }

    public async Task<IResult> UpdateAsync(UserModel model)
    {
        var validation = await new UpdateUserModelValidator().ValidateAsync(model);

        if (validation.Failed)
        {
            return Result.Fail(validation.Message);
        }

        var user = await _userRepository.GetAsync(model.Id);

        if (user == default)
        {
            return Result.Success();
        }

        user.ChangeFullName(model.Name, model.Surname);

        user.ChangeEmail(model.Email);

        await _userRepository.UpdateAsync(user.Id, user);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
```

#### Factory

The **Factory** class is responsible for creating a object.

```csharp
public static class UserFactory
{
    public static User Create(UserModel model, Auth auth)
    {
        return new User
        (
            new FullName(model.Name, model.Surname),
            new Email(model.Email),
            auth
        );
    }
}
```

## Domain

#### Entity

The **Entity** class is responsible for business rules and domain logic.

It must have an identity.

Property values must be assigned in the constructor and only be changed by methods.

```csharp
public class User : Entity<long>
{
    public User
    (
        FullName fullName,
        Email email,
        Auth auth
    )
    {
        FullName = fullName;
        Email = email;
        Auth = auth;
        Activate();
    }

    public User(long id) : base(id) { }

    public FullName FullName { get; private set; }

    public Email Email { get; private set; }

    public Status Status { get; private set; }

    public Auth Auth { get; private set; }

    public void Activate()
    {
        Status = Status.Active;
    }

    public void Inactivate()
    {
        Status = Status.Inactive;
    }

    public void ChangeFullName(string name, string surname)
    {
        FullName = new FullName(name, surname);
    }

    public void ChangeEmail(string email)
    {
        Email = new Email(email);
    }
}
```

#### Value Object

The **ValueObject** class is responsible for grouping data that adds value to domain or an entity.

It must have no identity.

Property values must be assigned in the constructor.

```csharp
public sealed class FullName : ValueObject
{
    public FullName(string name, string surname)
    {
        Name = name;
        Surname = surname;
    }

    public string Name { get; }

    public string Surname { get; }

    protected override IEnumerable<object> GetEquals()
    {
        yield return Name;
        yield return Surname;
    }
}
```

## Model

#### Model

The **Model** class is responsible for containing a set of data.

```csharp
public class SignInModel
{
    public string Login { get; set; }

    public string Password { get; set; }
}
```

#### Model Validator

The **ModelValidator** class is responsible for validating the model with defined rules and messages.

```csharp
public sealed class SignInModelValidator : Validator<SignInModel>
{
    public SignInModelValidator()
    {
        RuleFor(x => x.Login).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
```

## Database

#### Context

The **Context** class is responsible for configuring and mapping the database.

```csharp
public sealed class Context : DbContext
{
    public Context(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.AddConfigurationsFromAssembly();
        builder.Seed();
    }
}
```

#### Context Factory

The **ContextFactory** class is responsible for generating [Entity Framework Core Migrations](https://docs.microsoft.com/ef/core/managing-schemas/migrations).

```csharp
public sealed class ContextFactory : IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<Context>();

        builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Database;");

        return new Context(builder.Options);
    }
}
```

#### Context Seed

The **ContextSeed** class is responsible for seeding initial data.

```csharp
public static class ContextSeed
{
    public static void Seed(this ModelBuilder builder)
    {
        builder.SeedUsers();
    }

    private static void SeedUsers(this ModelBuilder builder)
    {
        builder.Entity<User>(user =>
        {
            user.HasData(new
            {
                Id = 1L,
                Status = Status.Active,
                AuthId = 1L
            });

            user.OwnsOne(owned => owned.FullName).HasData(new
            {
                UserId = 1L,
                Name = "Administrator",
                Surname = "Administrator"
            });

            user.OwnsOne(owned => owned.Email).HasData(new
            {
                UserId = 1L,
                Value = "administrator@administrator.com"
            });
        });
    }
}
```

#### Unit of Work

The **UnitOfWork** class is responsible for managing database transactions.

```csharp
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly Context _context;

    public UnitOfWork(Context context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}
```

#### Configuration

The **Configuration** class is responsible for configuring and mapping an entity to a table.

```csharp
public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "User");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Property(user => user.Status).IsRequired();

        builder.OwnsOne(user => user.FullName, ownedBuilder =>
        {
            ownedBuilder.Property(fullName => fullName.Name).HasColumnName(nameof(FullName.Name)).HasMaxLength(100).IsRequired();
            ownedBuilder.Property(fullName => fullName.Surname).HasColumnName(nameof(FullName.Surname)).HasMaxLength(200).IsRequired();
        });

        builder.OwnsOne(user => user.Email, ownedBuilder =>
        {
            ownedBuilder.Property(email => email.Value).HasColumnName(nameof(User.Email)).HasMaxLength(300).IsRequired();
            ownedBuilder.HasIndex(email => email.Value).IsUnique();
        });

        builder.HasOne(user => user.Auth);
    }
}
```

#### Repository

The **Repository** class is responsible for abstracting and isolating data persistence.

```csharp
public sealed class UserRepository : EFRepository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context) { }

    public Task<long> GetAuthIdByUserIdAsync(long id)
    {
        return Queryable.Where(UserExpression.Id(id)).Select(UserExpression.AuthId).SingleOrDefaultAsync();
    }

    public Task<UserModel> GetByIdAsync(long id)
    {
        return Queryable.Where(UserExpression.Id(id)).Select(UserExpression.Model).SingleOrDefaultAsync();
    }

    public Task UpdateStatusAsync(User user)
    {
        return UpdatePartialAsync(user.Id, new { user.Status });
    }
}
```

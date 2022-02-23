# Scopes

If Worker classes are registered as Sinleton or Scoped then

Singleton and Scoped, Worker1 all fields have the same object, only Worker2 instace has different Transient object
Also in SerciveInFunction where function calls ```services.GetService<class>();``` Singleton and Scoped services are same even if Workers are registered as Transient
```diff
Caller     Function          Singleton                            Scoped                               Transient
Worker1 1  ServiceInjected   4f1f39e6-a979-4122-a5f5-a2db61b2e367 ad00fc9f-6e40-4294-8bee-ca5c04149c35 5e1810b4-16b6-4708-ac29-c1e5be7fd543
Worker1 2  ServiceInjected   4f1f39e6-a979-4122-a5f5-a2db61b2e367 ad00fc9f-6e40-4294-8bee-ca5c04149c35 5e1810b4-16b6-4708-ac29-c1e5be7fd543
Worker2 1  ServiceInjected   4f1f39e6-a979-4122-a5f5-a2db61b2e367 ad00fc9f-6e40-4294-8bee-ca5c04149c35 a9090d71-70cb-4f3f-a667-6ab9f9129e40
Static     SerciveInFunction 4f1f39e6-a979-4122-a5f5-a2db61b2e367 ad00fc9f-6e40-4294-8bee-ca5c04149c35 1aba87c5-a9a7-4338-9961-f9cb7e618e2d
Static     SerciveInFunction 4f1f39e6-a979-4122-a5f5-a2db61b2e367 ad00fc9f-6e40-4294-8bee-ca5c04149c35 0e310414-088e-48e4-bc73-c78a5ceea964
Static     SerciveInScope    4f1f39e6-a979-4122-a5f5-a2db61b2e367 e739c8dd-deed-4cda-86c1-6d78af14bdfa 914c55e4-40ef-48eb-95fd-d5e3430bd293
Static     SerciveInScope    4f1f39e6-a979-4122-a5f5-a2db61b2e367 bf3bbfaa-e924-420d-a920-26690bb61a74 fc574d43-b555-4023-a98d-7d5f82dee4d3
```

When Workers are registered as Transient then each instance will get its own Transient Services
```
Caller     Function        Singleton                            Scoped                               Transient
Worker1 1  ServiceInjected aa3120fc-bd28-4af2-b257-3d4a689f8040 c361adf9-95a8-4c2d-b5dc-2e6bb7f8328f 8d208c6a-2349-45d1-afe0-7688af6fa366
Worker1 2  ServiceInjected aa3120fc-bd28-4af2-b257-3d4a689f8040 c361adf9-95a8-4c2d-b5dc-2e6bb7f8328f 9b435e56-cf5c-4c90-a5fe-e6c58177a9e4
Worker2 1  ServiceInjected aa3120fc-bd28-4af2-b257-3d4a689f8040 c361adf9-95a8-4c2d-b5dc-2e6bb7f8328f 9ea98bf5-31f1-429c-9ac2-9b5ab8e1ec29
```
